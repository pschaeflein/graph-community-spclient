using Graph.Community.Middleware;
using Microsoft.Kiota.Http.HttpClientLibrary.Middleware.Options;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Graph.Community
{
  public class SPClientOptions
  {
    /// <summary>
    /// The UserAgentInfo for decorating SharePoint traffic.
    /// </summary>
    public SharePointThrottlingDecoration? UserAgentInfo { get; set; }

    /// <summary>
    /// A <see cref="IHttpMessageLogger"/> implementation to use from the Logging middleware
    /// </summary>
    public IHttpMessageLogger? MessageLogger { get; set; }

    public SPClientOptions() { }
    public SPClientOptions(string companyName, string appName, string appVersion, bool isv)
    {
      this.UserAgentInfo = new SharePointThrottlingDecoration()
      {
        CompanyName = companyName,
        AppName = appName,
        AppVersion = appVersion,
        ISV = isv
      };
    }
  }

  [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
  public struct SharePointThrottlingDecoration
  {
    public string CompanyName { get; set; }
    public string AppName { get; set; }
    public string AppVersion { get; set; }
    public bool ISV { get; set; }

    public readonly bool IsEmpty()
    {
      return string.IsNullOrEmpty(CompanyName) &&
             string.IsNullOrEmpty(AppName) &&
             string.IsNullOrEmpty(AppName) &&
             !ISV;
    }

    public readonly UserAgentHandlerOption ToUserAgentHandlerOption()
    {
      var isvDecoration = ISV ? "ISV" : "NONISV";
      var product = $"{isvDecoration}|{CompanyName}|{AppName}";
      return new()
      {
        ProductName = product,
        ProductVersion= AppVersion,
        Enabled = true
      };
    }

    public readonly ProductInfoHeaderValue ToUserAgent()
    {
      var isvDecoration = ISV ? "ISV" : "NONISV";
      var product = $"{isvDecoration}|{CompanyName}|{AppName}";
      return new ProductInfoHeaderValue(product, AppVersion);
    }

    private string GetDebuggerDisplay()
    {
      return ToUserAgent().ToString();
    }
  }
}
