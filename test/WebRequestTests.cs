using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using NSubstitute;

namespace Graph.Community.Tests
{
  public class WebRequestTests(RequestResponseSerializationFixture fixture):IClassFixture<RequestResponseSerializationFixture>
  {
    readonly RequestResponseSerializationFixture fixture = fixture;

    private readonly string mockSpoUrl = "https://mock.sharepoint.com";
    private readonly string mockServerRelativeSiteUrl = "mockSite";

    [Fact]
    public void Get_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web";

      var client = new Graph.Community.SPClient(fixture.Adapter);

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

      var client = new Graph.Community.SPClient(fixture.Adapter);

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

    [Fact]
    public void EnsureUser_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/ensureuser";

      var client = new Graph.Community.SPClient(fixture.Adapter);

      // ACT
      var requestBody = new EnsureUserRequest() { LogonName = "paul@mock.sharepoint.com" };
      var webRequest = client[mockServerRelativeSiteUrl]._api.Web.Ensureuser.ToPostRequestInformation(requestBody);
      webRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = webRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public async Task EnsureUser_GeneratesCorrectRequestBody()
    {
      // ARRANGE
      var expectedLogonName = "paul@mock.sharepoint.com";

      // When the request is sent through the adapter
      // save it so we can validate the content of the request
      RequestInformation? postRequest = null;
      await fixture.Adapter.SendAsync(
          Arg.Do<RequestInformation>(req => postRequest = req),
          Arg.Any<ParsableFactory<SPUser>>(),
          Arg.Any<Dictionary<string, ParsableFactory<IParsable>>?>(),
          Arg.Any<CancellationToken>());

      var requestBody = new EnsureUserRequest() { LogonName = "paul@mock.sharepoint.com" };

      var client = new Graph.Community.SPClient(fixture.Adapter);

      // ACT
      await client[mockServerRelativeSiteUrl]._api.Web.Ensureuser.PostAsync(requestBody);
      var actualBody = await fixture.DeserializeAsync<EnsureUserRequest>(postRequest?.Content);

      // ASSERT
      Assert.NotNull(postRequest);
      Assert.NotNull(actualBody);
      Assert.Equal(expectedLogonName, actualBody.LogonName);

    }
  }
}
