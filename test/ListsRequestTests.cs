using Microsoft.Kiota.Abstractions;
using NSubstitute;

namespace Graph.Community.Tests
{
  public class ListsRequestTests
  {
    private readonly string mockSpoUrl = "https://mock.sharepoint.com";
    private readonly string mockServerRelativeSiteUrl = "mockSite";
    private readonly Guid mockListId = new ("a5252fcf-f1d0-4baf-aa21-a50e6d91bb17");

    [Fact]
    public void List_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/lists";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var listsRequest = client[mockServerRelativeSiteUrl]._api.Web.Lists.ToGetRequestInformation();
      listsRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = listsRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public void List_WithExpand_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/lists?%24select=Id,Title";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var listsRequest = client[mockServerRelativeSiteUrl]._api.Web.Lists.ToGetRequestInformation(c =>
      {
        c.QueryParameters.Select = ["Id", "Title"];
      });
      listsRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = listsRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }


    [Fact]
    public void Get_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/lists/getById('{mockListId}')";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new Graph.Community.SPClient(adapter);

      // ACT
      var listsRequest = client[mockServerRelativeSiteUrl]
                          ._api
                          .Web
                          .Lists[mockListId]
                          .ToGetRequestInformation();
      listsRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = listsRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public void Get_WithExpand_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/lists/getById('{mockListId}')?%24expand=Forms";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new Graph.Community.SPClient(adapter);

      // ACT
      var webRequest = client[mockServerRelativeSiteUrl]._api.Web.Lists[mockListId].ToGetRequestInformation(c =>
      {
        c.QueryParameters.Expand = ["Forms"];
      });
      webRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = webRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }
  }
}
