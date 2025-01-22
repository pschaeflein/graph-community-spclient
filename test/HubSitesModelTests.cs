#nullable disable

using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;

namespace Graph.Community.Tests
{
  public class HubSitesModelTests(HubSitesModelFixture fixture) : IClassFixture<HubSitesModelFixture>
  {
    readonly HubSitesModelFixture fixture = fixture;

    [Fact]
    public void DeserializeHubSitesList()
    {
      // ARRANGE

      // ACT
      var hubSites = fixture.HubSites;

      // ASSERT
      Assert.Equal(5, hubSites.Value.Count);
    }

    [Fact]
    public void DeserializeHubSite()
    {
      // ARRANGE

      // ACT
      var hubSites = fixture.HubSites;
      var actual = hubSites.Value[2];

      // ASSERT
      Assert.Equal("MockSite2", actual.Title);
      Assert.Equal(new("6c621c00-1e1b-4d0a-a2af-aa2c2b3cbce6"), actual.ID);
      Assert.Equal("https://mock.sharepoint.com/sites/mockSite2", actual.SiteUrl);
    }
  }

  public class HubSitesModelFixture : IDisposable
  {
    public HubSitesModelFixture()
    {
      // initialize the fixture

      var responseStream = ResourceManager.GetEmbeddedResource("GetHubSitesResponse.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      HubSites = KiotaJsonSerializer.DeserializeAsync<Graph.Community.Item._api.HubSites.HubSitesGetResponse>(responseStream).GetAwaiter().GetResult();
    }

    public Item._api.HubSites.HubSitesGetResponse HubSites { get; private set; }

    public void Dispose()
    {
      // clean up the fixture

      GC.SuppressFinalize(this);
    }
  }
}
