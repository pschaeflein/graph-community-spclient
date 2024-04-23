using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using NSubstitute;
using System.ComponentModel.DataAnnotations;

namespace Graph.Community.Tests
{
  public class WebRequestTests
  {

    private readonly string mockSpoUrl = "https://mock.sharepoint.com";
    private readonly string mockServerRelativeSiteUrl = "mockSite";

    [Fact]
    public async Task GetAsyncBuildsCorrectUrlTemplate()
    {
      // Arrange
      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new Graph.Community.SPClient(adapter);

      // Act
      var webRequest = client[mockServerRelativeSiteUrl]._api.Web.ToGetRequestInformation();


      // Assert
      Assert.Equal("{+baseurl}/{serverRelativeSiteUrl}/_api/Web", webRequest.UrlTemplate);
    }

    [Fact]
    public async void Get_ReturnsCorrectResponse()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("GetWebResponse.json");

      //  need the client before calling the serialize
      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new Graph.Community.SPClient(adapter);

      // ACT
      var actual = KiotaJsonSerializer.Deserialize<Web>(responseStream);

      // ASSERT
      Assert.Equal("Mock Site", actual.Title);
      Assert.Equal("SitePages/This-one-is-not-posted.aspx", actual.WelcomePage);
      Assert.NotNull(actual.RegionalSettings);
      Assert.Equal(13, actual.RegionalSettings.TimeZone.Id);

    }

    //[Fact]
    //public async Task Get_GeneratesCorrectRequest()
    //{
    //  // ARRANGE
    //  var expectedUri = new Uri($"{mockWebUrl}/_api/web");

    //  using HttpResponseMessage response = new HttpResponseMessage();
    //  using GraphServiceTestClient gsc = GraphServiceTestClient.Create(response);

    //  // ACT
    //  await gsc.GraphServiceClient
    //              .SharePointAPI(mockWebUrl)
    //              .Web
    //              .Request()
    //              .GetAsync();

    //  // ASSERT
    //  gsc.HttpProvider.Verify(
    //    provider => provider.SendAsync(
    //      It.Is<HttpRequestMessage>(req =>
    //        req.Method == HttpMethod.Get &&
    //        req.RequestUri == expectedUri &&
    //        req.Headers.Authorization != null
    //      ),
    //      It.IsAny<HttpCompletionOption>(),
    //      It.IsAny<CancellationToken>()
    //      ),
    //    Times.Exactly(1)
    //  );
    //}

    //[Fact]
    //public void Get_GeneratesCorrectRequest_WithExpand()
    //{
    //  // ARRANGE
    //  var expectedUri = new Uri($"{mockWebUrl}/_api/web?$expand=RegionalSettings%2CRegionalSettings%2FTimeZone");

    //  using HttpResponseMessage response = new HttpResponseMessage();
    //  using GraphServiceTestClient testClient = GraphServiceTestClient.Create(response);

    //  // ACT
    //  var request = testClient.GraphServiceClient
    //                      .SharePointAPI(mockWebUrl)
    //                      .Web
    //                      .Request()
    //                      .Expand("RegionalSettings,RegionalSettings/TimeZone")
    //                      .GetHttpRequestMessage();



    //  // ASSERT
    //  Assert.Equal(expectedUri, request.RequestUri);
    //  Assert.Equal(SharePointAPIRequestConstants.Headers.AcceptHeaderValue, request.Headers.Accept.ToString());
    //  Assert.True(request.Headers.Contains(SharePointAPIRequestConstants.Headers.ODataVersionHeaderName), $"Header does not contain {SharePointAPIRequestConstants.Headers.ODataVersionHeaderName} header");
    //  Assert.Equal(SharePointAPIRequestConstants.Headers.ODataVersionHeaderValue, string.Join(',', request.Headers.GetValues(SharePointAPIRequestConstants.Headers.ODataVersionHeaderName)));
    //}

    //[Fact]
    //public async Task GetChanges_GeneratesCorrectRequest()
    //{
    //  // ARRANGE
    //  var query = new ChangeQuery()
    //  {
    //    Add = true
    //  };
    //  var expectedUri = new Uri($"{mockWebUrl}/_api/web/GetChanges");
    //  var expectedContent = "{\"query\":{\"Add\":true}}";

    //  using HttpResponseMessage response = new HttpResponseMessage();
    //  using GraphServiceTestClient gsc = GraphServiceTestClient.Create(response);

    //  // ACT
    //  await gsc.GraphServiceClient
    //              .SharePointAPI(mockWebUrl)
    //              .Web
    //              .Request()
    //              .GetChangesAsync(query);
    //  var actualContent = gsc.HttpProvider.ContentAsString;

    //  // ASSERT
    //  gsc.HttpProvider.Verify(
    //    provider => provider.SendAsync(
    //      It.Is<HttpRequestMessage>(req =>
    //        req.Method == HttpMethod.Post &&
    //        req.RequestUri == expectedUri &&
    //        req.Headers.Authorization != null
    //      ),
    //      It.IsAny<HttpCompletionOption>(),
    //      It.IsAny<CancellationToken>()
    //    ),
    //    Times.Exactly(1)
    //  );

    //  Assert.Equal(Microsoft.Graph.CoreConstants.MimeTypeNames.Application.Json, gsc.HttpProvider.ContentHeaders.ContentType.MediaType);
    //  Assert.Equal(expectedContent, actualContent);
    //}

    //[Fact]
    //public async Task EnsureUser_NullParameter_Throws()
    //{
    //  using HttpResponseMessage response = new HttpResponseMessage();
    //  using GraphServiceTestClient gsc = GraphServiceTestClient.Create(response);

    //  await Assert.ThrowsAsync<ArgumentNullException>(
    //    async () => await gsc.GraphServiceClient
    //                            .SharePointAPI(mockWebUrl)
    //                            .Web
    //                            .Request()
    //                            .EnsureUserAsync(null)
    //  );
    //}

    //[Fact]
    //public async Task EnsureUser_GeneratesCorrectRequest()
    //{
    //  // ARRANGE
    //  var expectedUri = new Uri($"{mockWebUrl}/_api/web/ensureuser");
    //  var expectedContent = "{\"logonName\":\"alexw\"}";


    //  using HttpResponseMessage response = new HttpResponseMessage();
    //  using GraphServiceTestClient gsc = GraphServiceTestClient.Create(response);

    //  // ACT
    //  await gsc.GraphServiceClient
    //              .SharePointAPI(mockWebUrl)
    //              .Web
    //              .Request()
    //              .EnsureUserAsync("alexw");
    //  var actualContent = gsc.HttpProvider.ContentAsString;

    //  // ASSERT
    //  gsc.HttpProvider.Verify(
    //    provider => provider.SendAsync(
    //      It.Is<HttpRequestMessage>(req =>
    //        req.Method == HttpMethod.Post &&
    //        req.RequestUri == expectedUri &&
    //        req.Headers.Authorization != null
    //      ),
    //      It.IsAny<HttpCompletionOption>(),
    //      It.IsAny<CancellationToken>()
    //    ),
    //    Times.Exactly(1)
    //  );

    //  Assert.Equal(Microsoft.Graph.CoreConstants.MimeTypeNames.Application.Json, gsc.HttpProvider.ContentHeaders.ContentType.MediaType);
    //  Assert.Equal(expectedContent, actualContent);
    //}

    //[Fact]
    //public async Task EnsureUser_ReturnsCorrectResponse()
    //{
    //  // ARRANGE
    //  var responseContent = ResourceManager.GetHttpResponseContent("EnsureUserResponse.json");
    //  HttpResponseMessage responseMessage = new HttpResponseMessage()
    //  {
    //    StatusCode = HttpStatusCode.OK,
    //    Content = new StringContent(responseContent),
    //  };


    //  using (responseMessage)
    //  using (GraphServiceTestClient gsc = GraphServiceTestClient.Create(responseMessage))
    //  {
    //    // ACT
    //    var response = await gsc.GraphServiceClient
    //                    .SharePointAPI(mockWebUrl)
    //                    .Web
    //                    .Request()
    //                    .EnsureUserAsync("alexw");
    //    var actual = response;

    //    // ASSERT
    //    Assert.Equal(14, actual.Id);
    //    Assert.False(actual.IsSiteAdmin);
    //    Assert.Equal("Alex Wilber", actual.Title);
    //    Assert.Equal(SPPrincipalType.User, actual.PrincipalType);
    //    Assert.Equal("alexw@mock.onmicrosoft.com", actual.UserPrincipalName);
    //  }
    //}

    //[Fact]
    //public async Task GetAssociatedGroups_GeneratesCorrectRequest()
    //{
    //  // ARRANGE
    //  var expectedUri = new Uri($"{mockWebUrl}/_api/web?$expand=associatedownergroup%2Cassociatedmembergroup%2Cassociatedvisitorgroup&$select=id%2Ctitle%2Cassociatedownergroup%2Cassociatedmembergroup%2Cassociatedvisitorgroup");

    //  using HttpResponseMessage response = new HttpResponseMessage();
    //  using GraphServiceTestClient gsc = GraphServiceTestClient.Create(response);

    //  // ACT
    //  await gsc.GraphServiceClient
    //              .SharePointAPI(mockWebUrl)
    //              .Web
    //              .Request()
    //              .GetAssociatedGroupsAsync();
    //  var actualContent = gsc.HttpProvider.ContentAsString;

    //  // ASSERT
    //  gsc.HttpProvider.Verify(
    //    provider => provider.SendAsync(
    //      It.Is<HttpRequestMessage>(req =>
    //        req.Method == HttpMethod.Get &&
    //        req.RequestUri == expectedUri &&
    //        req.Headers.Authorization != null
    //      ),
    //      It.IsAny<HttpCompletionOption>(),
    //      It.IsAny<CancellationToken>()
    //    ),
    //    Times.Exactly(1)
    //  );
    //}

    //[Fact]
    //public async Task GetAssociatedGroupsWithUsers_GeneratesCorrectRequest()
    //{
    //  // ARRANGE
    //  var expectedUri = new Uri($"{mockWebUrl}/_api/web?$expand=associatedownergroup%2Cassociatedmembergroup%2Cassociatedvisitorgroup%2Cassociatedownergroup%2Fusers%2Cassociatedmembergroup%2Fusers%2Cassociatedvisitorgroup%2Fusers&$select=id%2Ctitle%2Cassociatedownergroup%2Cassociatedmembergroup%2Cassociatedvisitorgroup");

    //  using HttpResponseMessage response = new HttpResponseMessage();
    //  using GraphServiceTestClient gsc = GraphServiceTestClient.Create(response);

    //  // ACT
    //  await gsc.GraphServiceClient
    //              .SharePointAPI(mockWebUrl)
    //              .Web
    //              .Request()
    //              .GetAssociatedGroupsAsync(true);
    //  var actualContent = gsc.HttpProvider.ContentAsString;

    //  // ASSERT
    //  gsc.HttpProvider.Verify(
    //    provider => provider.SendAsync(
    //      It.Is<HttpRequestMessage>(req =>
    //        req.Method == HttpMethod.Get &&
    //        req.RequestUri == expectedUri &&
    //        req.Headers.Authorization != null
    //      ),
    //      It.IsAny<HttpCompletionOption>(),
    //      It.IsAny<CancellationToken>()
    //    ),
    //    Times.Exactly(1)
    //  );

    //}

    //[Fact]
    //public async Task GetAssociatedGroups_ReturnsCorrectResponse()
    //{
    //  // ARRANGE
    //  var responseContent = ResourceManager.GetHttpResponseContent("GetWebAssociatedGroupsResponse.json");
    //  HttpResponseMessage responseMessage = new HttpResponseMessage()
    //  {
    //    StatusCode = HttpStatusCode.OK,
    //    Content = new StringContent(responseContent),
    //  };


    //  using (responseMessage)
    //  using (GraphServiceTestClient gsc = GraphServiceTestClient.Create(responseMessage))
    //  {
    //    // ACT
    //    var actual = await gsc.GraphServiceClient
    //                    .SharePointAPI(mockWebUrl)
    //                    .Web
    //                    .Request()
    //                    .GetAssociatedGroupsAsync();

    //    // ASSERT
    //    Assert.NotNull(actual.AssociatedMemberGroup);
    //    Assert.IsType<Group>(actual.AssociatedMemberGroup);
    //    Assert.NotNull(actual.AssociatedOwnerGroup);
    //    Assert.IsType<Group>(actual.AssociatedOwnerGroup);
    //    Assert.NotNull(actual.AssociatedVisitorGroup);
    //    Assert.IsType<Group>(actual.AssociatedVisitorGroup);
    //  }

    //}

    //[Fact]
    //public async Task GetAssociatedGroupsWithUsers_ReturnsCorrectResponse()
    //{
    //  // ARRANGE
    //  var responseContent = ResourceManager.GetHttpResponseContent("GetWebAssociatedGroupsWithUsersResponse.json");
    //  HttpResponseMessage responseMessage = new HttpResponseMessage()
    //  {
    //    StatusCode = HttpStatusCode.OK,
    //    Content = new StringContent(responseContent),
    //  };


    //  using (responseMessage)
    //  using (GraphServiceTestClient gsc = GraphServiceTestClient.Create(responseMessage))
    //  {
    //    // ACT
    //    var actual = await gsc.GraphServiceClient
    //                    .SharePointAPI(mockWebUrl)
    //                    .Web
    //                    .Request()
    //                    .GetAssociatedGroupsAsync(true);

    //    // ASSERT
    //    Assert.NotNull(actual.AssociatedMemberGroup);
    //    Assert.IsType<Group>(actual.AssociatedMemberGroup);
    //    Assert.Equal(2, actual.AssociatedMemberGroup.Users.Count);
    //    Assert.NotNull(actual.AssociatedOwnerGroup);
    //    Assert.IsType<Group>(actual.AssociatedOwnerGroup);
    //    Assert.Single(actual.AssociatedOwnerGroup.Users);
    //    Assert.NotNull(actual.AssociatedVisitorGroup);
    //    Assert.IsType<Group>(actual.AssociatedVisitorGroup);
    //    Assert.Empty(actual.AssociatedVisitorGroup.Users);
    //  }
    //}

  }
}
