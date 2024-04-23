using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System.Net;

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
      // Arrange
      var requestInfo = new RequestInformation
      {
        HttpMethod = Method.GET,
        URI = new("http://localhost")
      };
      var requestMessage = await requestAdapter.ConvertToNativeRequestAsync<HttpRequestMessage>(requestInfo);
      Assert.Empty(requestMessage.Headers);

      // Act
      var response = await _invoker.SendAsync(requestMessage, new CancellationToken());

      // Assert

      //Assert.Single(response.RequestMessage?.Headers!);
      Assert.Single(response.RequestMessage?.Headers!.Accept);
      Assert.Equal(SharePointAPIRequestConstants.Headers.AcceptHeaderValue, response.RequestMessage?.Headers!.Accept.First().ToString(), StringComparer.OrdinalIgnoreCase);

      Assert.Single(response.RequestMessage?.Headers!.GetValues(SharePointAPIRequestConstants.Headers.ODataVersionHeaderName));
      Assert.Equal(SharePointAPIRequestConstants.Headers.ODataVersionHeaderValue, response.RequestMessage?.Headers!.GetValues(SharePointAPIRequestConstants.Headers.ODataVersionHeaderName).First().ToString(), StringComparer.OrdinalIgnoreCase);

      //Assert.Contains(SharePointAPIRequestConstants.Headers.AcceptHeaderValue, webRequest.Headers[SharePointAPIRequestConstants.Headers.AcceptHeaderName]);
      //Assert.Contains(SharePointAPIRequestConstants.Headers.ODataVersionHeaderName, webRequest.Headers);
      //Assert.Contains(SharePointAPIRequestConstants.Headers.ODataVersionHeaderValue, webRequest.Headers[SharePointAPIRequestConstants.Headers.ODataVersionHeaderName]);

      Assert.Equal(requestMessage, response.RequestMessage);

    }

    //[Fact]
    //public async Task DisabledUserAgentHandlerDoesNotChangeRequest()
    //{
    //  // Arrange
    //  var requestInfo = new RequestInformation
    //  {
    //    HttpMethod = Method.GET,
    //    URI = new Uri("http://localhost"),
    //  };
    //  requestInfo.AddRequestOptions(new[] {
    //            new UserAgentHandlerOption
    //            {
    //                Enabled = false
    //            }
    //        });
    //  // Act and get a request message
    //  var requestMessage = await requestAdapter.ConvertToNativeRequestAsync<HttpRequestMessage>(requestInfo);
    //  Assert.Empty(requestMessage.Headers);

    //  // Act
    //  var response = await _invoker.SendAsync(requestMessage, new CancellationToken());

    //  // Assert the request stays the same
    //  Assert.Empty(response.RequestMessage?.Headers!);
    //  Assert.Equal(requestMessage, response.RequestMessage);
    //}
    //[Fact]
    //public async Task EnabledUserAgentHandlerAddsHeaderValue()
    //{
    //  // Arrange
    //  var requestInfo = new RequestInformation
    //  {
    //    HttpMethod = Method.GET,
    //    URI = new Uri("http://localhost"),
    //  };
    //  var defaultOption = new UserAgentHandlerOption();
    //  // Act and get a request message
    //  var requestMessage = await requestAdapter.ConvertToNativeRequestAsync<HttpRequestMessage>(requestInfo);
    //  Assert.Empty(requestMessage.Headers);

    //  // Act
    //  var response = await _invoker.SendAsync(requestMessage, new CancellationToken());

    //  // Assert
    //  Assert.Single(response.RequestMessage?.Headers!);
    //  Assert.Single(response.RequestMessage?.Headers!.UserAgent);
    //  Assert.Equal(response.RequestMessage?.Headers!.UserAgent.First().Product.Name, defaultOption.ProductName, StringComparer.OrdinalIgnoreCase);
    //  Assert.Equal(response.RequestMessage?.Headers!.UserAgent.First().Product.Version, defaultOption.ProductVersion, StringComparer.OrdinalIgnoreCase);
    //  Assert.Equal(response.RequestMessage?.Headers!.UserAgent.ToString(), $"{defaultOption.ProductName}/{defaultOption.ProductVersion}", StringComparer.OrdinalIgnoreCase);
    //  Assert.Equal(requestMessage, response.RequestMessage);
    //}

    //[Fact]
    //public async Task DoesntAddProductTwice()
    //{
    //  // Arrange
    //  var requestInfo = new RequestInformation
    //  {
    //    HttpMethod = Method.GET,
    //    URI = new Uri("http://localhost"),
    //  };
    //  var defaultOption = new UserAgentHandlerOption();
    //  // Act and get a request message
    //  var requestMessage = await requestAdapter.ConvertToNativeRequestAsync<HttpRequestMessage>(requestInfo);
    //  Assert.Empty(requestMessage.Headers);

    //  // Act
    //  var response = await _invoker.SendAsync(requestMessage, new CancellationToken());
    //  response = await _invoker.SendAsync(requestMessage, new CancellationToken());

    //  // Assert
    //  Assert.Single(response.RequestMessage?.Headers!);
    //  Assert.Single(response.RequestMessage?.Headers!.UserAgent);
    //  Assert.Equal(response.RequestMessage?.Headers!.UserAgent.ToString(), $"{defaultOption.ProductName}/{defaultOption.ProductVersion}", StringComparer.OrdinalIgnoreCase);
    //}

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
