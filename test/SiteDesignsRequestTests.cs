using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;
using NSubstitute;
using System.Text.Json;

namespace Graph.Community.Tests
{
  public class SiteDesignsRequestTests
  {
    private readonly string mockSpoUrl = "https://mock.sharepoint.com";
    private readonly string mockServerRelativeSiteUrl = "mockSite";

    [Fact]
    public void GetAll_GeneratesRequest()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Microsoft.SharePoint.Utilities.WebTemplateExtensions.SiteScriptUtility.GetSiteDesigns";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new Graph.Community.SPClient(adapter);

      // ACT
      var webRequest = client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.GetSiteDesigns.ToPostRequestInformation();
      webRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = webRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public async Task GetMetadata_GeneratesCorrectRequest()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Microsoft.SharePoint.Utilities.WebTemplateExtensions.SiteScriptUtility.GetSiteDesignMetadata";

      var adapter = Substitute.For<IRequestAdapter>();

      // Add JsonSerializationWriter to serialize Post objects
      adapter.SerializationWriterFactory.GetSerializationWriter("application/json")
          .Returns(sw => new JsonSerializationWriter());

      // When the request is sent through the adapter
      // save it so we can validate the content of the request
      RequestInformation? actualRequest = null;
      await adapter.SendAsync(
          Arg.Do<RequestInformation>(req => actualRequest = req),
          Arg.Any<ParsableFactory<SiteDesign>>(),
          Arg.Any<Dictionary<string, ParsableFactory<IParsable>>?>(),
          Arg.Any<CancellationToken>());

      var requestBody = new SiteDesignMetadataRequest() { Id = Guid.NewGuid() };

      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);


      // ACT
      var siteDesignMetadataRequest = client[mockServerRelativeSiteUrl]._api.SiteScriptUtility.GetSiteDesignMetadata.ToPostRequestInformation(requestBody);
      siteDesignMetadataRequest.PathParameters.Add("baseurl", mockSpoUrl);

      //var sdm = await client[mockServerRelativeSiteUrl]._api.SiteDesignMetadata.PostAsync(requestBody);
      var siteDesign = await adapter.SendAsync<SiteDesign>(siteDesignMetadataRequest, SiteDesign.CreateFromDiscriminatorValue, null, default);



      // ASSERT
      Assert.NotNull(actualRequest);
      Assert.Equal(expectedUrl, actualRequest.URI.ToString());

      // Deserialize the request body
      var actualBody = JsonSerializer.Deserialize<SiteDesignMetadataRequest>(
          actualRequest.Content,
          new JsonSerializerOptions
          {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
          });

      Assert.NotNull(actualBody);
      Assert.Equal(requestBody.Id, actualBody.Id);
    }
  }
}
