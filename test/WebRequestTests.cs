using Microsoft.Kiota.Abstractions;
using NSubstitute;

namespace Graph.Community.Tests
{
  public class WebRequestTests
  {
    private readonly string mockSpoUrl = "https://mock.sharepoint.com";
    private readonly string mockServerRelativeSiteUrl = "mockSite";

    [Fact]
    public void Get_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new Graph.Community.SPClient(adapter);

      // ACT
      var webRequest = client[mockServerRelativeSiteUrl]._api.Web.ToGetRequestInformation();
      webRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = webRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public void Get_WithExpand_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web?%24expand=UserCustomActions,SiteGroups";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var webRequest = client[mockServerRelativeSiteUrl]._api.Web.ToGetRequestInformation(c =>
      {
        c.QueryParameters.Expand = ["UserCustomActions", "SiteGroups"];
      });
      webRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = webRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }
  }
}
