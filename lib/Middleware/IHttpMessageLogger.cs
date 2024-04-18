using System.Threading.Tasks;

namespace Kiota.SharePoint
{
  public interface IHttpMessageLogger
  {
    Task WriteLine(string value);
  }
}
