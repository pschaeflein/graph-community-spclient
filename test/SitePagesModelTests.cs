#nullable disable

using Graph.Community.Item._api.SitePages;
using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;

namespace Graph.Community.Tests
{
  public class SitePagesModelTests
  {
    [Fact]
    public async Task DeserializeSitePagesGetResponse()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("SitePagesCollectionResponse.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<SitePagesGetResponse>(responseStream);

      // ASSERT
      Assert.Equal(3, actual.Value.Count);
    }

    [Fact]
    public async Task DeserializeSitePage()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("SP.Publishing.SitePage.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<SitePage>(responseStream);

      // ASSERT
      Assert.Equal(2, actual.Id);
      Assert.Equal("SPFX-Adaptive-Test", actual.Title);
      Assert.Equal("SitePages/SPFX-Adaptive-Test.aspx", actual.Url);
      Assert.Equal("https://mock.sharepoint.com/sites/mockSite/SitePages/SPFX-Adaptive-Test.aspx", actual.AbsoluteUrl);
      Assert.Equal("0d264f60-1306-48a2-bb16-e36f6225b834", actual.UniqueId.ToString());
      Assert.Equal("https://media.akamai.odsp.cdn.office.net/mock.sharepoint.com/_layouts/15/images/sitepagethumbnail.png", actual.BannerThumbnailUrl);
      Assert.Equal("Example description", actual.Description);
    }
  }
}
