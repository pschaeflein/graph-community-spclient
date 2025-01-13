#nullable disable

using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;

namespace Graph.Community.Tests
{
  /*
   *  Ensure that the MockApi model classes match the responses from SharePoint API
   */
  public class MockApiModelTests
  {
    [Fact]
    public async Task ModelWeb()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("GetWebResponse.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<Web>(responseStream);

      // ASSERT
      Assert.Equal("Mock Site", actual.Title);
      Assert.Equal("SitePages/This-one-is-not-posted.aspx", actual.WelcomePage);
      Assert.NotNull(actual.RegionalSettings);
      Assert.Equal(13, actual.RegionalSettings.TimeZone.Id);
      Assert.NotEmpty(actual.AdditionalData);
    }

    [Fact]
    public async Task ModelSitePages()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("GetSitePagesResponse.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<SitePageCollectionResponse>(responseStream);

      // ASSERT
      Assert.Equal(3, actual.Value.Count());
    }

    [Fact]
    public async Task ModelSitePage()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("GetSitePagesResponse.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var pages = await KiotaJsonSerializer.DeserializeAsync<SitePageCollectionResponse>(responseStream);
      var actual = pages.Value[1];

      // ASSERT
      Assert.Equal(2, actual.Id);
      Assert.Equal("SPFX-Adaptive-Test", actual.Title);
      Assert.Equal("SitePages/SPFX-Adaptive-Test.aspx", actual.Url);
      Assert.Equal("https://mock.sharepoint.com/sites/mockSite/SitePages/SPFX-Adaptive-Test.aspx", actual.AbsoluteUrl);
      Assert.Equal("0d264f60-1306-48a2-bb16-e36f6225b834", actual.UniqueId.ToString());
      Assert.Equal("https://media.akamai.odsp.cdn.office.net/mock.sharepoint.com/_layouts/15/images/sitepagethumbnail.png", actual.BannerThumbnailUrl);
      Assert.Equal("Example description", actual.Description);


    }

    [Fact]
    public async Task ModelUserCustomActions()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("UserCustomActions.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<UserCustomAction>(responseStream);

      // ASSERT
      Assert.Equal("ApplicationCustomizer1", actual.Title);
      Assert.NotNull(actual.ClientSideComponentId);
      Assert.NotEmpty(actual.AdditionalData);
    }
  }
}
