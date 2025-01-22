using Microsoft.Kiota.Abstractions;
using NSubstitute;

namespace Graph.Community.Tests
{
  public class SitePagesRequestTests
  {
    private readonly string mockSpoUrl = "https://mock.sharepoint.com";
    private readonly string mockServerRelativeSiteUrl = "mockSite";

    [Fact]
    public void GetAll_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/SitePages/Pages";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var sitepagesRequest = client[mockServerRelativeSiteUrl]._api.SitePages.ToGetRequestInformation();
      sitepagesRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = sitepagesRequest.URI.ToString();


      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public void Get_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/SitePages/Pages(4)";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var sitepagesRequest = client[mockServerRelativeSiteUrl]._api.SitePages[4].ToGetRequestInformation();
      sitepagesRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = sitepagesRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }
  }
}
