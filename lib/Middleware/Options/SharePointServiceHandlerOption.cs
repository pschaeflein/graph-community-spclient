using Microsoft.Kiota.Abstractions;

namespace Kiota.SharePoint
{
  public class SharePointServiceHandlerOption : IRequestOption
  {
    public bool DisableTelemetry { get; set; }
    public string? ResourceUri { get; set; }
  }
}
