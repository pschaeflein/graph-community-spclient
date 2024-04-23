using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Graph.Community.SPClient.Sample
{
  public class DotNetILoggerHttpMessageLogger : IHttpMessageLogger
	{
		private readonly ILogger logger;
		private readonly LogLevel logLevel;

		public DotNetILoggerHttpMessageLogger(
			ILogger<DotNetILoggerHttpMessageLogger> logger,
			IOptions<DotNetILoggerSettings> dotNetILoggerOptions)
		{
			this.logger = logger;
			this.logLevel = dotNetILoggerOptions?.Value?.LogLevel ?? LogLevel.Trace;
		}

		public async Task WriteLine(string message)
		{
			logger.Log(logLevel, message);
		}

	}
}
