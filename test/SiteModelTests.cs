#nullable disable

using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;

namespace Graph.Community.Tests
{
  public class SiteModelTests
  {
    [Fact]
    public async Task DeserializeSite()
    {
      // ARRANGE
      var resourceStream = ResourceManager.GetEmbeddedResource("SP.Site.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<SPSite>(resourceStream);

      // ASSERT
      Assert.Equal("57754187-c3d8-43a7-9d0a-3d0a66fa2c21", actual.Id);
      Assert.Equal("00000000-0000-0000-0000-000000000000", actual.HubSiteId);
      Assert.False(actual.IsHubSite);
      Assert.Equal("00000000-0000-0000-0000-000000000000", actual.GroupId);
      Assert.Equal("/sites/mockSite", actual.ServerRelativeUrl);
      Assert.Equal("1;1;57754187-c3d8-43a7-9d0a-3d0a66fa2c21;638738473245400000;1107410976", actual.CurrentChangeToken.StringValue);
      Assert.Equal("GBR", actual.GeoLocation);
      Assert.Equal("https://mock.sharepoint.com/sites/mockSite", actual.PrimaryUri);
      Assert.NotEmpty(actual.AdditionalData);
    }
  }
}
