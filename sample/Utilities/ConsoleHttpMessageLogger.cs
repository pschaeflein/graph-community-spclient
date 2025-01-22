using Graph.Community.Middleware;

namespace Graph.Community.SPClient.Sample
{
  class ConsoleHttpMessageLogger : IHttpMessageLogger
  {
    public Task WriteLine(string value)
    {
      Console.WriteLine(value);
      return Task.CompletedTask;
    }
  }
}
