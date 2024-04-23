using System.Threading.Tasks;

namespace Graph.Community.Middleware
{
  public interface IHttpMessageLogger
  {
    Task WriteLine(string value);
  }
}
