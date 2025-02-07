using Graph.Community.Item._api.SiteScriptUtility.ApplySiteDesign;
using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using NSubstitute;

namespace Graph.Community.Tests
{
  public class SiteDesignsRequestTests(RequestResponseSerializationFixture fixture) : IClassFixture<RequestResponseSerializationFixture>
  {
    readonly RequestResponseSerializationFixture fixture = fixture;

    private readonly string mockSpoUrl = "https://mock.sharepoint.com";
    private readonly string mockServerRelativeSiteUrl = "mockSite";

    [Fact]
    public void List_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Microsoft.SharePoint.Utilities.WebTemplateExtensions.SiteScriptUtility.GetSiteDesigns";

      var client = new Graph.Community.SPClient(fixture.Adapter);

      // ACT
      var siteDesignsRequest = client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.GetSiteDesigns.ToPostRequestInformation();
      siteDesignsRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = siteDesignsRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public void GetMetadata_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Microsoft.SharePoint.Utilities.WebTemplateExtensions.SiteScriptUtility.GetSiteDesignMetadata";

      var client = new Graph.Community.SPClient(fixture.Adapter);

      // ACT
      var requestBody = new SiteDesignMetadataRequest() { Id = Guid.NewGuid() };
      var siteDesignMetadataRequest = client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.GetSiteDesignMetadata.ToPostRequestInformation(requestBody);
      siteDesignMetadataRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = siteDesignMetadataRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public async Task GetMetadata_GeneratesCorrectRequestBody()
    {
      // ARRANGE

      // When the request is sent through the adapter
      // save it so we can validate the content of the request
      RequestInformation? actualRequest = null;
      await fixture.Adapter.SendAsync(
          Arg.Do<RequestInformation>(req => actualRequest = req),
          Arg.Any<ParsableFactory<SiteDesignMetadata>>(),
          Arg.Any<Dictionary<string, ParsableFactory<IParsable>>?>(),
          Arg.Any<CancellationToken>());

      var requestBody = new SiteDesignMetadataRequest() { Id = Guid.NewGuid() };

      var client = new SPClient(fixture.Adapter);


      // ACT
      var siteDesignMetadataRequest = await client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.GetSiteDesignMetadata.PostAsync(requestBody);
      var actualBody = await fixture.DeserializeAsync<SiteDesignMetadataRequest>(actualRequest?.Content);


      // ASSERT
      Assert.NotNull(actualRequest);
      Assert.NotNull(actualBody);
      Assert.Equal(requestBody.Id, actualBody.Id);
    }

    [Fact]
    public void Apply_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Microsoft.SharePoint.Utilities.WebTemplateExtensions.SiteScriptUtility.ApplySiteDesign";

      var client = new Graph.Community.SPClient(fixture.Adapter);

      // ACT
      var requestBody = new ApplySiteDesignRequest()
      {
        SiteDesignId = Guid.NewGuid(),
        WebUrl = "https://mock.sharepoint.com/sites/mockSite"
      };

      var applySiteDesignRequest = client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.ApplySiteDesign.ToPostRequestInformation(requestBody);
      applySiteDesignRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = applySiteDesignRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public async Task Apply_GeneratesCorrectRequestBody()
    {
      // ARRANGE

      // When the request is sent through the adapter
      // save it so we can validate the content of the request
      RequestInformation? actualRequest = null;
      await fixture.Adapter.SendAsync(
          Arg.Do<RequestInformation>(req => actualRequest = req),
          Arg.Any<ParsableFactory<ApplySiteDesignPostResponse>>(),
          Arg.Any<Dictionary<string, ParsableFactory<IParsable>>?>(),
          Arg.Any<CancellationToken>());

      var requestBody = new ApplySiteDesignRequest()
      {
        SiteDesignId = Guid.NewGuid(),
        WebUrl = "https://mock.sharepoint.com/sites/mockSite"
      };

      var client = new SPClient(fixture.Adapter);


      // ACT
      var applySiteDesignRequest = await client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.ApplySiteDesign.PostAsync(requestBody);
      var actualBody = await fixture.DeserializeAsync<ApplySiteDesignRequest>(actualRequest?.Content);

      // ASSERT
      Assert.NotNull(actualRequest);
      Assert.NotNull(actualBody);
      Assert.Equal(requestBody.SiteDesignId, actualBody.SiteDesignId);
      Assert.Equal(requestBody.WebUrl, actualBody.WebUrl);
    }

    [Fact]
    public void Create_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Microsoft.SharePoint.Utilities.WebTemplateExtensions.SiteScriptUtility.CreateSiteDesign";

      var client = new Graph.Community.SPClient(fixture.Adapter);

      // ACT
      var requestBody = new CreateSiteDesignRequest()
      {
        Info = new()
        {
          Description = "Mock Site Design",
          PreviewImageAltText = "Mock Site Design",
          PreviewImageUrl = "https://mock.sharepoint.com/sites/mockSite/_layouts/15/images/siteicon.png",
          SiteScriptIds = [Guid.NewGuid().ToString()],
          Title = "Mock Site Design",
          WebTemplate = "64",
        },
      };

      var createSiteDesignRequest = client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.CreateSiteDesign.ToPostRequestInformation(requestBody);
      createSiteDesignRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = createSiteDesignRequest.URI.ToString();

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
          Arg.Any<ParsableFactory<SiteDesignMetadata>>(),
          Arg.Any<Dictionary<string, ParsableFactory<IParsable>>?>(),
          Arg.Any<CancellationToken>());

      var requestBody = new CreateSiteDesignRequest()
      {
        Info = new()
        {
          Description = "Mock Site Design",
          PreviewImageAltText = "Mock Site Design",
          PreviewImageUrl = "https://mock.sharepoint.com/sites/mockSite/_layouts/15/images/siteicon.png",
          SiteScriptIds = [Guid.NewGuid().ToString()],
          Title = "Mock Site Design",
          WebTemplate = "64",
        },
      };

      var client = new SPClient(fixture.Adapter);


      // ACT
      var siteDesignMetadata = await client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.CreateSiteDesign.PostAsync(requestBody);

      var actualBody = await fixture.DeserializeAsync<CreateSiteDesignRequest>(actualRequest?.Content);

      // ASSERT
      Assert.NotNull(actualRequest);
      Assert.NotNull(actualBody?.Info);
      Assert.Equal(requestBody.Info.Description, actualBody.Info.Description);
      Assert.Equal(requestBody.Info.PreviewImageAltText, actualBody.Info.PreviewImageAltText);
      Assert.Equal(requestBody.Info.PreviewImageUrl, actualBody.Info.PreviewImageUrl);
      Assert.Equal(requestBody.Info.SiteScriptIds, actualBody.Info.SiteScriptIds);
      Assert.Equal(requestBody.Info.Title, actualBody.Info.Title);
      Assert.Equal(requestBody.Info.WebTemplate, actualBody.Info.WebTemplate);
    }

    [Fact]
    public void Update_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Microsoft.SharePoint.Utilities.WebTemplateExtensions.SiteScriptUtility.UpdateSiteDesign";

      var client = new Graph.Community.SPClient(fixture.Adapter);

      // ACT
      var requestBody = new UpdateSiteDesignRequest();
      var updateSiteScriptRequest = client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.UpdateSiteDesign.ToPostRequestInformation(requestBody);
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
          Arg.Any<ParsableFactory<SiteDesignMetadata>>(),
          Arg.Any<Dictionary<string, ParsableFactory<IParsable>>?>(),
          Arg.Any<CancellationToken>());

      var client = new SPClient(fixture.Adapter);

      // ACT
      var requestBody = new UpdateSiteDesignRequest
      {
        UpdateInfo = new()
        {
          Id = Guid.NewGuid(),
          Title = "Updated title",
          Description = "Updated description",
          PreviewImageAltText = "Updated Site Design",
          PreviewImageUrl = "https://mock.sharepoint.com/sites/mockSite/_layouts/15/images/siteicon.png",
          SiteScripts = [Guid.NewGuid().ToString()],
          WebTemplate = "64",
          Version = 99,
        }
      };

      var siteDesignMetadata = await client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.UpdateSiteDesign.PostAsync(requestBody);

      using var sr = new StreamReader(actualRequest!.Content);
      var actualBody = await fixture.DeserializeAsync<UpdateSiteDesignRequest>(actualRequest?.Content);

      // ASSERT
      Assert.NotNull(actualRequest);
      Assert.Equal(requestBody.UpdateInfo.Id, actualBody?.UpdateInfo?.Id);
      Assert.Equal(requestBody.UpdateInfo.Title, actualBody?.UpdateInfo?.Title);
      Assert.Equal(requestBody.UpdateInfo.Description, actualBody?.UpdateInfo?.Description);
      Assert.Equal(requestBody.UpdateInfo.PreviewImageAltText, actualBody?.UpdateInfo?.PreviewImageAltText);
      Assert.Equal(requestBody.UpdateInfo.PreviewImageUrl, actualBody?.UpdateInfo?.PreviewImageUrl);
      Assert.Equal(requestBody.UpdateInfo.SiteScripts, actualBody?.UpdateInfo?.SiteScripts);
      Assert.Equal(requestBody.UpdateInfo.WebTemplate, actualBody?.UpdateInfo?.WebTemplate);
      Assert.Equal(requestBody.UpdateInfo.Version, actualBody?.UpdateInfo?.Version);
    }

    [Fact]
    public void Delete_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Microsoft.SharePoint.Utilities.WebTemplateExtensions.SiteScriptUtility.DeleteSiteDesign";

      var client = new Graph.Community.SPClient(fixture.Adapter);

      // ACT
      var requestBody = new SiteDesignMetadataRequest() { Id = Guid.NewGuid() };
      var siteScriptMetadataRequest = client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.DeleteSiteDesign.ToPostRequestInformation(requestBody);
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

      var client = new SPClient(fixture.Adapter);


      // ACT
      var requestBody = new SiteDesignMetadataRequest() { Id = Guid.NewGuid() };
      await client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.DeleteSiteDesign.PostAsync(requestBody);
      var actualBody = await fixture.DeserializeAsync<SiteDesignMetadataRequest>(actualRequest?.Content);


      // ASSERT
      Assert.NotNull(actualRequest);
      Assert.NotNull(actualBody);
      Assert.Equal(requestBody.Id, actualBody.Id);
    }

  }
}
