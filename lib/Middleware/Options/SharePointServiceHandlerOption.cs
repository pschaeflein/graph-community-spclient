using Microsoft.Kiota.Abstractions;

namespace Graph.Community
{
  public class SharePointServiceHandlerOption : IRequestOption
  {
    public bool DisableTelemetry { get; set; }
    public string? ResourceUri { get; set; }
  }
}
