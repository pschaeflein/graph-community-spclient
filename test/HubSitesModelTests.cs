#nullable disable

using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;

namespace Graph.Community.Tests
{
  public class HubSitesModelTests() 
  {
    [Fact]
    public async Task DeserializeHubSitesList()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("Collection_HubSites.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var hubSites = await KiotaJsonSerializer.DeserializeAsync<Graph.Community.Item._api.HubSites.HubSitesGetResponse>(responseStream);

      // ASSERT
      Assert.Equal(5, hubSites.Value.Count);
    }

    [Fact]
    public async Task DeserializeHubSite()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("Collection_HubSites.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var hubSites = await KiotaJsonSerializer.DeserializeAsync<Graph.Community.Item._api.HubSites.HubSitesGetResponse>(responseStream);
      var actual = hubSites.Value[2];

      // ASSERT
      Assert.Equal("MockSite2", actual.Title);
      Assert.Equal(new("6c621c00-1e1b-4d0a-a2af-aa2c2b3cbce6"), actual.ID);
      Assert.Equal("https://mock.sharepoint.com/sites/mockSite2", actual.SiteUrl);
      Assert.NotEmpty(actual.AdditionalData);
    }
  }
}
