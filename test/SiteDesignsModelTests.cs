#nullable disable

using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Serialization.Json;
using Graph.Community.Models;

namespace Graph.Community.Tests
{
  public class SiteDesignsModelTests
  {
    [Fact]
    public async Task Deserialize_Collection_WebTemplateExtensions_SiteDesignMetadata()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("Collection_WebTemplateExtensions.SiteDesignMetadata.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<Graph.Community.Item._api.SiteScriptUtility.GetSiteDesigns.GetSiteDesignsPostResponse>(responseStream);

      // ASSERT
      Assert.Equal(2, actual.Value.Count);
    }

    [Fact]
    public async Task Deserialize_WebTemplateExtensions_SiteDesignMetadata()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("WebTemplateExtensions.SiteDesignMetadata.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<Graph.Community.Models.SiteDesign>(responseStream);

      // ASSERT

      Assert.Equal(new Guid("52693c3f-4f86-49e1-8d93-bb18ad8d22f8"), actual.Id);
      Assert.Equal("mockSiteDesignDescription", actual.Description);
      Assert.False(actual.IsDefault);
      Assert.Equal("mockPreviewImageAltText", actual.PreviewImageAltText);
      Assert.Equal("mockPreviewImageUrl", actual.PreviewImageUrl);
      Assert.Equal(2, actual.SiteScriptIds.Count);
      Assert.Equal("ebb4bcd6-1c19-47fc-9910-fb618d2d3c13", actual.SiteScriptIds[1]);
      Assert.Equal("mockThumbnailUrl", actual.ThumbnailUrl);
      Assert.Equal("mockSiteDesignTitle", actual.Title);
      Assert.Equal("64", actual.WebTemplate);
      Assert.Equal(1, actual.Version);
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
      Assert.Equal(6, actual.Count);

      Assert.Equal(0, actual[1].ErrorCode);
      Assert.Equal(SiteScriptActionOutcome.Success, actual[1].Outcome);
      Assert.Equal("Create site column Project name", actual[1].Title);
      Assert.Null(actual[1].OutcomeText);
      Assert.Equal("createSiteColumn",actual[1].Verb);

      Assert.Equal(0, actual[2].ErrorCode);
      Assert.Equal(SiteScriptActionOutcome.NoOp, actual[2].Outcome);
      Assert.Equal("Create content type Customer", actual[2].Title);
      Assert.Null(actual[2].OutcomeText);
      Assert.Equal("createContentType", actual[2].Verb);
    }

    [Fact]
    public async Task DeserializeCollection_WebTemplateExtensions_SiteDesignRun()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("Collection_WebTemplateExtensions.SiteDesignRun.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var responseObject = await KiotaJsonSerializer.DeserializeAsync<Graph.Community.Item._api.SiteScriptUtility.GetSiteDesignRuns.GetSiteDesignRunsPostResponse>(responseStream);
      var actual = responseObject.Value;


      // ASSERT
      Assert.Equal(6, actual.Count);

      Assert.Equal(new Guid("8ae74935-f1ab-4174-b8e1-39bbc9bed925"), actual[1].SiteDesignID);
      Assert.Equal("Community", actual[1].SiteDesignTitle);
      Assert.Equal(1, actual[1].SiteDesignVersion);
      Assert.Equal(new Guid("c1fe3d1c-a525-4deb-b30b-98853ff640d4"), actual[1].SiteID);
      Assert.Equal(new Guid("3a0f5c22-d8eb-4603-919e-c75e60021bf3"), actual[1].WebID);
      Assert.Equal(1738359106000, actual[1].StartTime);
    }
  }
}
