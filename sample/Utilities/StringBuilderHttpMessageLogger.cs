using Graph.Community.Middleware;
using System.Text;

namespace Graph.Community.SPClient.Sample
{
  class StringBuilderHttpMessageLogger : IHttpMessageLogger
  {
    private readonly StringBuilder sb = new();

    public string GetLog()
    {
      var log = sb.ToString();
      sb.Clear();
      return log;
    }

    public Task WriteLine(string value)
    {
      sb.AppendLine(value);
      return Task.CompletedTask;
    }
  }
}
