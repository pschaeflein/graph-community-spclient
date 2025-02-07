using Microsoft.Kiota.Abstractions;
using NSubstitute;

namespace Graph.Community.Tests
{
  public class WebFileRequestTests
  {
    private readonly string mockSpoUrl = "https://mock.sharepoint.com";
    private readonly string mockServerRelativeSiteUrl = "mockSite";

    [Fact]
    public void GetById_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var fileId = Guid.NewGuid();
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/GetFileById('{fileId}')";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new Graph.Community.SPClient(adapter);

      // ACT
      var fileRequest = client[mockServerRelativeSiteUrl]._api.Web.GetFileById(fileId).ToGetRequestInformation();
      fileRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = fileRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Theory]
    [InlineData("/sites/mockSite/Site Assets/mockFile.txt")]
    [InlineData("/sites/mockSite/SiteAssets/fileWith%.jpg")]
    [InlineData("/sites/mockSite/SiteAss#ts/fileWith#.jpg")]
    public void GetFileByServerRelativePath_GeneratesCorrectUrlTemplate(string filePath)
    {
      /*
       *  Despite the parameter name in the url, the file path can be URI encoded.
       *  The Kiota encoded does not encode spaces
       */

      // ARRANGE
      var encodedPath = Uri.EscapeDataString(filePath).Replace("%20"," ");  // kiota doesn't encode spaces...
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/GetFileByServerRelativePath(DecodedUrl=@path)?@path=%27{encodedPath}%27";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new Graph.Community.SPClient(adapter);

      // ACT

      var fileRequest = client[mockServerRelativeSiteUrl]._api.Web.GetFileByServerRelativePath.ToGetRequestInformation(r =>
      {
        r.QueryParameters.Path = $"'{filePath}'";
      });

      fileRequest.PathParameters.Add("baseurl", mockSpoUrl);
      var actualUrl = fileRequest.URI.ToString();


      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }
  }
}
