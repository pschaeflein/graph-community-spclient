using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;
using NSubstitute;
using System.Text.Json;

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

    [Fact]
    public void EnsureUser_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/web/ensureuser";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      var requestBody = new EnsureUserRequest() { LogonName = "paul@mock.sharepoint.com" };
      var webRequest = client[mockServerRelativeSiteUrl]._api.Web.Ensureuser.ToPostRequestInformation(requestBody);
      webRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = webRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

    [Fact]
    public async Task EnsureUser_GeneratesCorrectRequest()
    {
      // ARRANGE
      var expectedLogonName = "paul@mock.sharepoint.com";

      var adapter = Substitute.For<IRequestAdapter>();

      // Add JsonSerializationWriter to serialize Post objects
      adapter.SerializationWriterFactory.GetSerializationWriter("application/json")
          .Returns(sw => new JsonSerializationWriter());

      // When the request is sent through the adapter
      // save it so we can validate the content of the request
      RequestInformation? postRequest = null;
      await adapter.SendAsync(
          Arg.Do<RequestInformation>(req =>
          {
            postRequest = req;
          }),
          Arg.Any<ParsableFactory<User>>(),
          Arg.Any<Dictionary<string, ParsableFactory<IParsable>>?>(),
          Arg.Any<CancellationToken>());

      var requestBody = new EnsureUserRequest() { LogonName = "paul@mock.sharepoint.com" };

      adapter.BaseUrl = mockSpoUrl;
      var client = new SPClient(adapter);

      // ACT
      await client[mockServerRelativeSiteUrl]._api.Web.Ensureuser.PostAsync(requestBody);

      // ASSERT
      Assert.NotNull(postRequest);
      // Deserialize the request body
      var actualRequest = JsonSerializer.Deserialize<EnsureUserRequest>(
          postRequest.Content,
          new JsonSerializerOptions
          {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
          });

      Assert.NotNull(actualRequest);
      Assert.Equal(expectedLogonName, actualRequest.LogonName);

    }
  }
}
