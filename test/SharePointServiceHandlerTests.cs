using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System.Net;

#nullable disable

namespace Graph.Community.Tests
{
  public class SharePointServiceHandlerTests
  {
    private readonly HttpMessageInvoker _invoker;
    private readonly HttpClientRequestAdapter requestAdapter;

    public SharePointServiceHandlerTests()
    {
      var spsvcHandler = new SharePointServiceHandler
      {
        InnerHandler = new FakeSuccessHandler()
      };
      this._invoker = new HttpMessageInvoker(spsvcHandler);
      requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider());
    }

    [Fact]
    public async Task HandlerAddsHeaders()
    {
      // ARRANGE
      var requestInfo = new RequestInformation
      {
        HttpMethod = Method.GET,
        URI = new("http://localhost")
      };
      var requestMessage = await requestAdapter.ConvertToNativeRequestAsync<HttpRequestMessage>(requestInfo);
      Assert.Empty(requestMessage.Headers);

      // ACT
      var response = await _invoker.SendAsync(requestMessage, new CancellationToken());

      // Assert
      Assert.Single(response.RequestMessage.Headers.GetValues(SharePointAPIRequestConstants.Headers.ODataVersionHeaderName));
      Assert.Equal(SharePointAPIRequestConstants.Headers.ODataVersionHeaderValue, response.RequestMessage.Headers.GetValues(SharePointAPIRequestConstants.Headers.ODataVersionHeaderName).First().ToString(), StringComparer.OrdinalIgnoreCase);

      Assert.Equal(requestMessage, response.RequestMessage);
    }
  }

  internal class FakeSuccessHandler : DelegatingHandler
  {
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      var response = new HttpResponseMessage
      {
        StatusCode = HttpStatusCode.OK,
        RequestMessage = request
      };
      return Task.FromResult(response);
    }
  }

}
