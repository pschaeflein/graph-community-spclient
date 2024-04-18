using System.Text.Json.Serialization;

namespace Kiota.SharePoint.MockApi.Models
{
  public class GetSiteDesignMetadataRequest
  {
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
  }
}
