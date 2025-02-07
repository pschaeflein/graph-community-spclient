#nullable disable

using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;

namespace Graph.Community.Tests
{
  public class SiteScriptsModelTests
  {
    [Fact]
    public async Task Deserialize_WebTemplateExtensions_SiteScriptMetadata()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("WebTemplateExtensions.SiteScriptMetadata.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<Graph.Community.Models.SiteScriptMetadata>(responseStream);

      // ASSERT

      Assert.Equal(new Guid("379e5da0-e7c9-4889-a688-6f86be1a6ed9"), actual.Id);
      Assert.Equal("Apply the Green Theme", actual.Description);
      Assert.Equal("Green Theme", actual.Title);
      Assert.Equal(0, actual.Version);
      Assert.Null(actual.Content);
    }


    [Fact]
    public async Task Deserialize_Collection_WebTemplateExtensions_SiteScriptActionResult()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("Collection_WebTemplateExtensions.SiteScriptActionResult.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var responseObject = await KiotaJsonSerializer.DeserializeAsync<Graph.Community.Item._api.SiteScriptUtility.ApplySiteDesign.ApplySiteDesignPostResponse>(responseStream);
      var actual = responseObject.Value;

      // ASSERT
      Assert.Equal(7, actual.Count);

      Assert.Equal(0, actual[1].ErrorCode);
      Assert.Equal(0, actual[1].Outcome);
      Assert.Equal("Create site column Project name", actual[1].Title);
      Assert.Null(actual[1].OutcomeText);
      Assert.Equal("createSiteColumn", actual[1].Verb);

      Assert.Equal(0, actual[2].ErrorCode);
      Assert.Equal(2, actual[2].Outcome);
      Assert.Equal("Create content type Customer", actual[2].Title);
      Assert.Null(actual[2].OutcomeText);
      Assert.Equal("createContentType", actual[2].Verb);

      Assert.Equal(-1593311200, actual[6].ErrorCode);
      Assert.Equal(1, actual[6].Outcome);
      Assert.Equal("Apply theme \"Green\"", actual[6].Title);
    }
  }
}
