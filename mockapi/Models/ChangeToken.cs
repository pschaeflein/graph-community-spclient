using System.Text.Json.Serialization;

namespace Graph.Community.MockApi.Models
{
  public class ChangeToken
  {

#nullable enable

    [JsonPropertyName("StringValue")]
    public string? StringValue { get; set; }

#nullable restore
  }
}