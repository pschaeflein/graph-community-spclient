using System.Text.Json.Serialization;

namespace Graph.Community.MockApi.Models
{
  public class GetSiteDesignMetadataRequest
  {
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
  }
}
