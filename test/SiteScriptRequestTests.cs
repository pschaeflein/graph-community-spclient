using Graph.Community.Item._api.SiteScriptUtility.CreateSiteScript;
using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;
using NSubstitute;
using System.Text.Json;

namespace Graph.Community.Tests
{
  public class SiteScriptRequestTests(RequestResponseSerializationFixture fixture) : IClassFixture<RequestResponseSerializationFixture>
  {
    readonly RequestResponseSerializationFixture fixture = fixture;

    private readonly string mockSpoUrl = "https://mock.sharepoint.com";
    private readonly string mockServerRelativeSiteUrl = "mockSite";

    [Fact]
    public void List_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Microsoft.SharePoint.Utilities.WebTemplateExtensions.SiteScriptUtility.GetSiteScripts";

      var client = new Graph.Community.SPClient(fixture.Adapter);

      // ACT
      var siteScriptsRequest = client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.GetSiteScripts.ToPostRequestInformation();
      siteScriptsRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = siteScriptsRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public void Get_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Microsoft.SharePoint.Utilities.WebTemplateExtensions.SiteScriptUtility.GetSiteScriptMetadata";

      var client = new Graph.Community.SPClient(fixture.Adapter);

      // ACT
      var requestBody = new SiteScriptMetadataRequest() { Id = Guid.NewGuid() };
      var siteScriptMetadataRequest = client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.GetSiteScriptMetadata.ToPostRequestInformation(requestBody);
      siteScriptMetadataRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = siteScriptMetadataRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public async Task Get_GeneratesCorrectRequestBody()
    {
      // ARRANGE

      // When the request is sent through the adapter
      // save it so we can validate the content of the request
      RequestInformation? actualRequest = null;
      await fixture.Adapter.SendAsync(
          Arg.Do<RequestInformation>(req => actualRequest = req),
          Arg.Any<ParsableFactory<SiteScriptMetadata>>(),
          Arg.Any<Dictionary<string, ParsableFactory<IParsable>>?>(),
          Arg.Any<CancellationToken>());

      var requestBody = new SiteScriptMetadataRequest() { Id = Guid.NewGuid() };

      var client = new SPClient(fixture.Adapter);


      // ACT
      var siteScriptMetadataRequest = await client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.GetSiteScriptMetadata.PostAsync(requestBody);
      var actualBody = await fixture.DeserializeAsync<SiteDesignMetadataRequest>(actualRequest?.Content);


      // ASSERT
      Assert.NotNull(actualRequest);
      Assert.NotNull(actualBody);
      Assert.Equal(requestBody.Id, actualBody.Id);
    }

    [Theory]
    [InlineData("Mock Site Script", "Mock Site Script Description")]
    [InlineData("Mock Site Scr%pt", "Mock Site Script's Description")]
    [InlineData("Mock Site Scr#pt", "Mock Site Script Description")]
    public void Create_GeneratesCorrectUrlTemplate(string title, string description)
    {
      // ARRANGE
      var encodedTitle = Uri.EscapeDataString($"{title}").Replace("%20", " ");  // kiota doesn't encode spaces...;
      var encodedDescription = Uri.EscapeDataString($"{description}").Replace("%20", " ");  // kiota doesn't encode spaces...;

      // Kiota adds query parameters alphabetically
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Microsoft.SharePoint.Utilities.WebTemplateExtensions.SiteScriptUtility.CreateSiteScript(Title=@title,Description=@description)?@description={encodedDescription}&@title={encodedTitle}";

      var client = new Graph.Community.SPClient(fixture.Adapter);


      var actionsJson = "[]";
      using var jsonDocument = JsonDocument.Parse(actionsJson);
      var parseNode = new JsonParseNode(jsonDocument.RootElement);
      var actionsNode = parseNode.GetObjectValue(UntypedNode.CreateFromDiscriminatorValue);

      // ACT

      var siteScriptRequest = client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.CreateSiteScript.ToPostRequestInformation(
        body: new(),
        requestConfiguration: r =>
      {
        r.QueryParameters.Title = title;
        r.QueryParameters.Description = description;
      });


      siteScriptRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = siteScriptRequest.URI.ToString();


      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public async Task Create_GeneratesCorrectRequestBody()
    {
      // ARRANGE

      // When the request is sent through the adapter
      // save it so we can validate the content of the request
      RequestInformation? actualRequest = null;
      await fixture.Adapter.SendAsync(
          Arg.Do<RequestInformation>(req => actualRequest = req),
          Arg.Any<ParsableFactory<SiteScriptMetadata>>(),
          Arg.Any<Dictionary<string, ParsableFactory<IParsable>>?>(),
          Arg.Any<CancellationToken>());


      var scriptJson = "{\"$schema\":\"schema.json\",\"actions\":[{\"verb\":\"applyTheme\",\"themeName\":\"Green\"}],\"bindata\":{},\"version\":1}";

      using var jsonDocument = JsonDocument.Parse(scriptJson);
      var parseNode = new JsonParseNode(jsonDocument.RootElement);
      var requestBody = parseNode.GetObjectValue(CreateSiteScriptPostRequestBody.CreateFromDiscriminatorValue);

      var client = new SPClient(fixture.Adapter);

      // ACT
      var siteScriptMetadata = await client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.CreateSiteScript.PostAsync(requestBody);

      using var sr = new StreamReader(actualRequest!.Content);
      var actualBodyAsString = sr.ReadToEnd();

      // ASSERT
      Assert.NotNull(actualRequest);
      Assert.Equal(scriptJson, actualBodyAsString);
    }

    [Fact]
    public void Update_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Microsoft.SharePoint.Utilities.WebTemplateExtensions.SiteScriptUtility.UpdateSiteScript";

      var client = new Graph.Community.SPClient(fixture.Adapter);

      // ACT
      var requestBody = new UpdateSiteScriptRequest();
      var updateSiteScriptRequest = client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.UpdateSiteScript.ToPostRequestInformation(requestBody);
      updateSiteScriptRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = updateSiteScriptRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public async Task Update_GeneratesCorrectRequestBody()
    {
      // ARRANGE

      // When the request is sent through the adapter
      // save it so we can validate the content of the request
      RequestInformation? actualRequest = null;
      await fixture.Adapter.SendAsync(
          Arg.Do<RequestInformation>(req => actualRequest = req),
          Arg.Any<ParsableFactory<SiteScriptMetadata>>(),
          Arg.Any<Dictionary<string, ParsableFactory<IParsable>>?>(),
          Arg.Any<CancellationToken>());


      var scriptJson = "{\"$schema\":\"schema.json\",\"actions\":[{\"verb\":\"applyTheme\",\"themeName\":\"Green\"}],\"bindata\":{},\"version\":1}";

      //using var jsonDocument = JsonDocument.Parse(scriptJson);
      //var parseNode = new JsonParseNode(jsonDocument.RootElement);

      var client = new SPClient(fixture.Adapter);

      // ACT
      var requestBody = new UpdateSiteScriptRequest
      {
        UpdateInfo = new()
        {
          Id = Guid.NewGuid(),
          Title = "Updated title",
          Description = "Updated description",
          Version = 99,
          Content = scriptJson,
        }
      };

      var siteScriptMetadata = await client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.UpdateSiteScript.PostAsync(requestBody);

      using var sr = new StreamReader(actualRequest!.Content);
      //var actualBodyAsString = sr.ReadToEnd();
      var actualBody = await fixture.DeserializeAsync<UpdateSiteScriptRequest>(actualRequest?.Content);

      // ASSERT
      Assert.NotNull(actualRequest);
      Assert.Equal(requestBody.UpdateInfo.Id, actualBody?.UpdateInfo?.Id);
      Assert.Equal(requestBody.UpdateInfo.Title, actualBody?.UpdateInfo?.Title);
      Assert.Equal(requestBody.UpdateInfo.Description, actualBody?.UpdateInfo?.Description);
      Assert.Equal(requestBody.UpdateInfo.Version, actualBody?.UpdateInfo?.Version);
      Assert.Equal(requestBody.UpdateInfo.Content, actualBody?.UpdateInfo?.Content);
    }

    [Fact]
    public void Delete_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Microsoft.SharePoint.Utilities.WebTemplateExtensions.SiteScriptUtility.DeleteSiteScript";

      var client = new Graph.Community.SPClient(fixture.Adapter);

      // ACT
      var requestBody = new SiteScriptMetadataRequest() { Id = Guid.NewGuid() };
      var siteScriptMetadataRequest = client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.DeleteSiteScript.ToPostRequestInformation(requestBody);
      siteScriptMetadataRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = siteScriptMetadataRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public async Task Delete_GeneratesCorrectRequestBody()
    {
      // ARRANGE

      // When the request is sent through the adapter
      // save it so we can validate the content of the request
      RequestInformation? actualRequest = null;
      await fixture.Adapter.SendNoContentAsync(
          Arg.Do<RequestInformation>(req => actualRequest = req),
          Arg.Any<Dictionary<string, ParsableFactory<IParsable>>?>(),
          Arg.Any<CancellationToken>());

      var requestBody = new SiteScriptMetadataRequest() { Id = Guid.NewGuid() };

      var client = new SPClient(fixture.Adapter);


      // ACT
      await client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.DeleteSiteScript.PostAsync(requestBody);
      var actualBody = await fixture.DeserializeAsync<SiteDesignMetadataRequest>(actualRequest?.Content);


      // ASSERT
      Assert.NotNull(actualRequest);
      Assert.NotNull(actualBody);
      Assert.Equal(requestBody.Id, actualBody.Id);
    }
  }
}
