using System.Threading.Tasks;

namespace Graph.Community.Middleware
{
  class NullHttpMessageLogger : IHttpMessageLogger
  {
    public Task WriteLine(string value)
    {
      return Task.CompletedTask;
    }
  }
}
