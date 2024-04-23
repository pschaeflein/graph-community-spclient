using Graph.Community.Middleware;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System.Text;

#nullable disable

namespace Graph.Community.Tests
{
  public class LoggingMessageHandlerTests
  {
    [Fact]
    public async Task WritesToLogger()
    {
      // ARRANGE
      var logger = new StringBuilderHttpMessageLogger();
      var loggingHandler = new LoggingMessageHandler(logger, new FakeSuccessHandler());
      var invoker = new HttpMessageInvoker(loggingHandler);
      var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider());

      var requestInfo = new RequestInformation
      {
        HttpMethod = Method.GET,
        URI = new("http://localhost")
      };
      var requestMessage = await requestAdapter.ConvertToNativeRequestAsync<HttpRequestMessage>(requestInfo);

      // ACT
      _ = await invoker.SendAsync(requestMessage, new CancellationToken());
      var log = logger.GetLog(true);

      // ASSERT
      Assert.False(string.IsNullOrEmpty(log));

    }

  }

  class StringBuilderHttpMessageLogger : IHttpMessageLogger
  {
    private readonly StringBuilder logger = new StringBuilder();

    public string GetLog(bool clear)
    {
      var log = logger.ToString();
      if (clear)
      {
        logger.Clear();
      }
      return log;
    }

    public Task WriteLine(string value)
    {
      logger.AppendLine(value);
      return Task.CompletedTask;
    }
  }
}
