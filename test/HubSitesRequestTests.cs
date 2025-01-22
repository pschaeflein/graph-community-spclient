using Microsoft.Kiota.Abstractions;
using NSubstitute;

namespace Graph.Community.Tests
{
  public class HubSitesRequestTests
  {
    /*
     *  Ensure the mock api controllers generate the correct OpenAPI description.
     */
    private readonly string mockSpoUrl = "https://mock.sharepoint.com";
    private readonly string mockServerRelativeSiteUrl = "mockSite";

    [Fact]
    public void Get_GeneratesRequest()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/HubSites";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new Graph.Community.SPClient(adapter);

      // ACT
      var webRequest = client[mockServerRelativeSiteUrl]._api.HubSites.ToGetRequestInformation();
      webRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = webRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

  }
}
