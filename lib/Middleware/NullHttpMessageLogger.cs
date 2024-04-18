using System.Threading.Tasks;

namespace Kiota.SharePoint
{
  class NullHttpMessageLogger : IHttpMessageLogger
  {
    public Task WriteLine(string value)
    {
      return Task.CompletedTask;
    }
  }
}
