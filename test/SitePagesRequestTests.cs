using Microsoft.Kiota.Abstractions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Community.Tests
{
  public class SitePagesRequestTests
  {
    /*
     *  Ensure the mock api controllers generate the correct OpenAPI description.
     */
    private readonly string mockSpoUrl = "https://mock.sharepoint.com";
    private readonly string mockServerRelativeSiteUrl = "mockSite";

    [Fact]
    public async Task GetAll_GeneratesRequest()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/sitepages/pages";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var sitepagesRequest = client[mockServerRelativeSiteUrl]._api.Sitepages.Pages.ToGetRequestInformation();
      sitepagesRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = sitepagesRequest.URI.ToString();
      var actualAcceptHeader = sitepagesRequest.Headers[SharePointAPIRequestConstants.Headers.AcceptHeaderName].FirstOrDefault();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);

      Assert.Equal(SharePointAPIRequestConstants.Headers.AcceptHeaderValue, sitepagesRequest.Headers[SharePointAPIRequestConstants.Headers.AcceptHeaderName].First().ToString(), StringComparer.OrdinalIgnoreCase);
      Assert.Equal(SharePointAPIRequestConstants.Headers.AcceptHeaderValue, actualAcceptHeader);
    }

    [Fact]
    public async Task Get_GeneratesRequest()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/sitepages/pages(4)";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var sitepagesRequest = client[mockServerRelativeSiteUrl]._api.Sitepages.PagesWithListItemId(4).ToGetRequestInformation();
      sitepagesRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = sitepagesRequest.URI.ToString();
      var actualAcceptHeader = sitepagesRequest.Headers[SharePointAPIRequestConstants.Headers.AcceptHeaderName].FirstOrDefault();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);

      Assert.Equal(SharePointAPIRequestConstants.Headers.AcceptHeaderValue, sitepagesRequest.Headers[SharePointAPIRequestConstants.Headers.AcceptHeaderName].First().ToString(), StringComparer.OrdinalIgnoreCase);
      Assert.Equal(SharePointAPIRequestConstants.Headers.AcceptHeaderValue, actualAcceptHeader);
    }
  }
}
