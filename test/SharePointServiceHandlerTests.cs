using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System.Net;

#nullable disable

namespace Graph.Community.Tests
{
  public class SharePointServiceHandlerTests
  {
    [Fact]
    public async Task HandlerAddsHeaders()
    {
      // SETUP
      var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider());
      var spsvcHandler = new SharePointServiceHandler
      {
        InnerHandler = new FakeSuccessHandler()
      };
      var invoker = new HttpMessageInvoker(spsvcHandler);

      // ARRANGE
      var requestInfo = new RequestInformation
      {
        HttpMethod = Method.GET,
        URI = new("http://localhost")
      };
      var requestMessage = await requestAdapter.ConvertToNativeRequestAsync<HttpRequestMessage>(requestInfo);
      Assert.Empty(requestMessage.Headers);

      // ACT
      var response = await invoker.SendAsync(requestMessage, new CancellationToken());

      // Assert
      Assert.Single(response.RequestMessage.Headers.GetValues(SharePointAPIRequestConstants.Headers.ODataVersionHeaderName));
      Assert.Equal(SharePointAPIRequestConstants.Headers.ODataVersionHeaderValue, response.RequestMessage.Headers.GetValues(SharePointAPIRequestConstants.Headers.ODataVersionHeaderName).First().ToString(), StringComparer.OrdinalIgnoreCase);

      Assert.Equal(requestMessage, response.RequestMessage);
    }

    [Fact]
    public async Task HandlerThrowsWhenNotFound()
    {
      // SETUP
      var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider());
      var spsvcHandler = new SharePointServiceHandler
      {
        InnerHandler = new FakeNotFoundHandler()
      };
      var invoker = new HttpMessageInvoker(spsvcHandler);

      // ARRANGE
      var requestInfo = new RequestInformation
      {
        HttpMethod = Method.GET,
        URI = new("http://localhost")
      };
      var requestMessage = await requestAdapter.ConvertToNativeRequestAsync<HttpRequestMessage>(requestInfo);
      Assert.Empty(requestMessage.Headers);

      // ACT & ASSERT
      await Assert.ThrowsAsync<ODataError>(async () => await invoker.SendAsync(requestMessage, new CancellationToken()));
    }

    [Fact]
    public async Task HandlerParsesOdataError()
    {
      // SETUP
      var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider());
      var spsvcHandler = new SharePointServiceHandler
      {
        InnerHandler = new FakeNotFoundHandler()
      };
      var invoker = new HttpMessageInvoker(spsvcHandler);

      // ARRANGE
      var requestInfo = new RequestInformation
      {
        HttpMethod = Method.GET,
        URI = new("http://localhost")
      };
      var requestMessage = await requestAdapter.ConvertToNativeRequestAsync<HttpRequestMessage>(requestInfo);

      // ACT
      ODataError error = null;
      try
      {
        var result = await invoker.SendAsync(requestMessage, new CancellationToken());
      }
      catch (ODataError ode)
      {
        error = ode;
      }

      // ASSERT
      Assert.NotNull(error);
      Assert.Equal("404 FILE NOT FOUND", error.Message);
      Assert.Equal(404, error.ResponseStatusCode);
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

  internal class FakeNotFoundHandler : DelegatingHandler
  {
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      var response = new HttpResponseMessage(HttpStatusCode.NotFound);
      var responseContent = new StringContent("404 FILE NOT FOUND", new System.Net.Http.Headers.MediaTypeHeaderValue(System.Net.Mime.MediaTypeNames.Text.Plain));
      response.Content = responseContent;

      return Task.FromResult(response);
    }
  }
}
