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
