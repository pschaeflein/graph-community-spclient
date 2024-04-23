using Graph.Community.Middleware;

namespace Graph.Community.SPClient.Sample
{
  class ConsoleHttpMessageLogger : IHttpMessageLogger
  {
    public async Task WriteLine(string value)
    {
      Console.WriteLine(value);
    }
  }
}
