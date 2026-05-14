using Microsoft.Kiota.Abstractions;
using NSubstitute;

namespace Graph.Community.Tests
{
  public class ListItemsRequestTests
  {
    private readonly string mockSpoUrl = "https://mock.sharepoint.com";
    private readonly string mockServerRelativeSiteUrl = "mockSite";
    private readonly Guid mockListId = new("a5252fcf-f1d0-4baf-aa21-a50e6d91bb17");
    private readonly int mockItemId = 42;

    [Fact]
    public void Items_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/lists/getById('{mockListId}')/items";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var itemsRequest = client[mockServerRelativeSiteUrl]._api.Web.Lists[mockListId].Items.ToGetRequestInformation();
      itemsRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = itemsRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public void Items_WithSelect_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/lists/getById('{mockListId}')/items?%24select=Id,Title";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var itemsRequest = client[mockServerRelativeSiteUrl]._api.Web.Lists[mockListId].Items.ToGetRequestInformation(c =>
      {
        c.QueryParameters.Select = ["Id", "Title"];
      });
      itemsRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = itemsRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public void Items_WithExpand_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/lists/getById('{mockListId}')/items?%24expand=FieldValues";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var itemsRequest = client[mockServerRelativeSiteUrl]._api.Web.Lists[mockListId].Items.ToGetRequestInformation(c =>
      {
        c.QueryParameters.Expand = ["FieldValues"];
      });
      itemsRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = itemsRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public void Items_WithMultipleQueryParameters_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/lists/getById('{mockListId}')/items?%24expand=ContentType,FieldValues&%24select=Id,DisplayName";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var itemsRequest = client[mockServerRelativeSiteUrl]._api.Web.Lists[mockListId].Items.ToGetRequestInformation(c =>
      {
        c.QueryParameters.Expand = ["ContentType", "FieldValues"];
        c.QueryParameters.Select = ["Id", "DisplayName"];
      });
      itemsRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = itemsRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public void ItemById_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/lists/getById('{mockListId}')/items({mockItemId})";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var itemRequest = client[mockServerRelativeSiteUrl]._api.Web.Lists[mockListId].Items[mockItemId].ToGetRequestInformation();
      itemRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = itemRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public void ItemById_WithSelect_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/lists/getById('{mockListId}')/items({mockItemId})?%24select=Id,DisplayName";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var itemRequest = client[mockServerRelativeSiteUrl]._api.Web.Lists[mockListId].Items[mockItemId].ToGetRequestInformation(c =>
      {
        c.QueryParameters.Select = ["Id", "DisplayName"];
      });
      itemRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = itemRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public void ItemById_WithExpand_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/lists/getById('{mockListId}')/items({mockItemId})?%24expand=ContentType,FieldValuesAsText";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var itemRequest = client[mockServerRelativeSiteUrl]._api.Web.Lists[mockListId].Items[mockItemId].ToGetRequestInformation(c =>
      {
        c.QueryParameters.Expand = ["ContentType", "FieldValuesAsText"];
      });
      itemRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = itemRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public void ItemById_WithExpandAndSelect_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/lists/getById('{mockListId}')/items({mockItemId})?%24expand=FieldValues,Properties&%24select=Id,DisplayName";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var itemRequest = client[mockServerRelativeSiteUrl]._api.Web.Lists[mockListId].Items[mockItemId].ToGetRequestInformation(c =>
      {
        c.QueryParameters.Expand = ["FieldValues", "Properties"];
        c.QueryParameters.Select = ["Id", "DisplayName"];
      });
      itemRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = itemRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }
  }
}
