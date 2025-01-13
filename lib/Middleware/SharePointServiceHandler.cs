using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Http.HttpClientLibrary.Extensions;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Graph.Community
{
  public class SharePointServiceHandler : DelegatingHandler
  {
    /// <summary>
    /// Constructs a new <see cref="SharePointServiceHandler"/> 
    /// </summary>
    public SharePointServiceHandler() { }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      request.Headers.Add(SharePointAPIRequestConstants.Headers.ODataVersionHeaderName, SharePointAPIRequestConstants.Headers.ODataVersionHeaderValue);

      var response = await base.SendAsync(request, cancellationToken);

      if (!response.IsSuccessStatusCode)
      {
        using (response)
        {
          var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

          // first, see if the response is an ODataError...
          var odataError = await KiotaJsonSerializer.DeserializeAsync(responseContent, ODataError.CreateFromDiscriminatorValue);

          if (odataError!.Error == null)
          {
            odataError = this.ConvertErrorResponseAsync(responseContent);
          }

          if (odataError!.Error == null)
          {
            // we couldn't parse the error, so return generic message
            if (response != null && response.StatusCode == HttpStatusCode.NotFound)
            {
              odataError.Error = new() { Code = "itemNotFound" };
            }
            else
            {
              odataError.Error = new()
              {
                Code = "generalException",
                Message = "Unexpected exception returned from the service."
              };
            }
          }

          if (response != null)
          {
            odataError.ResponseStatusCode = (int)(response.StatusCode);
            if (response.Headers != null)
            {
              odataError.ResponseHeaders = response.Headers.ToDictionary(
                keySelector: h => h.Key,
                elementSelector: h => h.Value
              );
            }
          }

          throw odataError;
        }
      }

      return response;

    }

    /// <summary>
    /// Converts the <see cref="HttpRequestException"/> into an <see cref="ErrorResponse"/> object;
    /// </summary>
    /// <param name="response">The <see cref="HttpResponseMessage"/> to convert.</param>
    /// <returns>The <see cref="ErrorResponse"/> object.</returns>
    private ODataError? ConvertErrorResponseAsync(string responseContent)
    {
      try
      {
        // try our best to provide a helpful message...
        var responseObject = JsonDocument.Parse(responseContent).RootElement;
        var message = responseObject.TryGetProperty("error_description", out var errorDescription)
          ? errorDescription.ToString()
          : responseContent;

        var error = new ODataError()
        {
          Error = new()
          {
            Code = "SPError",
            Message = message
          }
        };
        error.AdditionalData.Add("responseContent", responseContent);

        return error;

      }
      catch (Exception)
      {
        // If there's an exception deserializing the error response,
        // return null and throw a generic ServiceException later.
        return null;
      }
    }


  }
}
