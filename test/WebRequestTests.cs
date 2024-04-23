using Microsoft.Kiota.Abstractions;
using NSubstitute;

namespace Graph.Community.Tests
{
  public class WebRequestTests
  {
    /*
     *  Ensure the mock api controllers generate the correct OpenAPI description/generated builders.
     */
    private readonly string mockSpoUrl = "https://mock.sharepoint.com";
    private readonly string mockServerRelativeSiteUrl = "mockSite";

    [Fact]
    public async Task Get_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Web";

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
    public void GetWithExpand_GeneratesCorrectUrlTemplate()
    {
      // ARRANGE
      var expectedUrl = $"{mockSpoUrl}/{mockServerRelativeSiteUrl}/_api/Web?%24expand=UserCustomActions&%24expand=SiteGroups";

      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockSpoUrl;
      var client = new Graph.Community.SPClient(adapter);

      // ACT
      var webRequest = client[mockServerRelativeSiteUrl]._api.Web.ToGetRequestInformation(c =>
      {
        c.QueryParameters.Expand = new string[] { "UserCustomActions", "SiteGroups" };
      });
      webRequest.PathParameters.Add("baseurl", mockSpoUrl);

      var actualUrl = webRequest.URI.ToString();

      // ASSERT
      Assert.Equal(expectedUrl, actualUrl);
    }

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
