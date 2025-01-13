using System.Text.Json.Serialization;

namespace Graph.Community.SPClient.MockApi.Models
{
  public class GetSiteDesignMetadataRequest
  {
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
  }
}
