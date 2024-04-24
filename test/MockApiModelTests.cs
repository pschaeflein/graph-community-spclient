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
    public void ModelWeb()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("GetWebResponse.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = KiotaJsonSerializer.Deserialize<Web>(responseStream);

      // ASSERT
      Assert.Equal("Mock Site", actual.Title);
      Assert.Equal("SitePages/This-one-is-not-posted.aspx", actual.WelcomePage);
      Assert.NotNull(actual.RegionalSettings);
      Assert.Equal(13, actual.RegionalSettings.TimeZone.Id);
      Assert.NotEmpty(actual.AdditionalData);
    }

    [Fact]
    public void ModelUserCustomActions()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("UserCustomActions.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = KiotaJsonSerializer.Deserialize<UserCustomAction>(responseStream);

      // ASSERT
      Assert.Equal("ApplicationCustomizer1", actual.Title);
      Assert.NotNull(actual.ClientSideComponentId);
      Assert.NotEmpty(actual.AdditionalData);
    }
  }
}
