using System.Text.Json.Serialization;

namespace Graph.Community.SPClient.MockApi.Models
{
  public class CollectionResponse<TCollectionType>
  {
    [JsonPropertyName("value")]
    public List<TCollectionType>? Value { get; set; }
  }
}
