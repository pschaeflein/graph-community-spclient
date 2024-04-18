using Kiota.SharePoint.Client;
using Kiota.SharePoint.Client.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using NSubstitute;

namespace Kiota.SharePoint.Test
{
  public class WebRequestTests
  {

    private readonly string mockWebUrl = "https://mock.sharepoint.com/sites/mockSite";

    private static readonly Web mockWeb = new()
    {
      RegionalSettings = new()
      {
        TimeZone = new()
        {
          Description = "(UTC-08:00) Pacific Time (US and Canada)",
          Id = 13,
          Information = new()
          {
            Bias = 480,
            DaylightBias = -60,
            StandardBias = 0
          }
        },
        AdjustHijriDays = 0,
        AlternateCalendarType = 0,
        //AM = "AM",
        CalendarType = 1,
        Collation = 25,
        CollationLCID = 2070,
        DateFormat = 0,
        DateSeparator = "/",
        DecimalSeparator = ".",
        DigitGrouping = "3;0",
        FirstDayOfWeek = 0,
        FirstWeekOfYear = 0,
        IsEastAsia = false,
        IsRightToLeft = false,
        IsUIRightToLeft = false,
        ListSeparator = ",",
        LocaleId = 1033,
        NegativeSign = "-",
        NegNumberMode = 1,
        //PM = "PM",
        PositiveSign = "",
        ShowWeeks = false,
        ThousandSeparator = ",",
        Time24 = false,
        TimeMarkerPosition = 0,
        TimeSeparator = ":",
        WorkDayEndHour = 1020,
        WorkDays = 62,
        WorkDayStartHour = 480
      },
      //AllowRssFeeds = true,
      //AlternateCssUrl = "",
      //AppInstanceId = "00000000-0000-0000-0000-000000000000",
      //ClassicWelcomePage = null,
      //Configuration = 0,
      //Created = "2022-05-25T23:07:10.863-07:00",
      CurrentChangeToken = new()
      {
        StringValue = "1;2;b3bb5585-bb7b-4fba-8619-a2bcfa2ff24e;637908031948500000;353893883"
      },
      //CustomMasterUrl = "/sites/mockSite/_catalogs/masterpage/seattle.master",
      //Description = "",
      //DesignPackageId = "96c933ac-3698-44c7-9f4a-5fd17d71af9e",
      //DocumentLibraryCalloutOfficeWebAppPreviewersDisabled = false,
      //EnableMinimalDownload = false,
      //FooterEmphasis = 0,
      FooterEnabled = true,
      FooterLayout = 0,
      //HeaderEmphasis = 0,
      //HeaderLayout = 2,
      //HideTitleInHeader = false,
      //HorizontalQuickLaunch = false,
      Id = "b3bb5585-bb7b-4fba-8619-a2bcfa2ff24e",
      //IsEduClass = false,
      //IsEduClassProvisionChecked = false,
      //IsEduClassProvisionPending = false,
      //IsHomepageModernized = false,
      //IsMultilingual = true,
      //IsRevertHomepageLinkHidden = false,
      //Language = 1033,
      //LastItemModifiedDate = "2022-06-09T15:46:56Z",
      //LastItemUserModifiedDate = "2022-06-09T14:35:38Z",
      //LogoAlignment = 0,
      //MasterUrl = "/sites/mockSite/_catalogs/masterpage/seattle.master",
      //MegaMenuEnabled = true,
      //NavAudienceTargetingEnabled = false,
      //NoCrawl = false,
      //ObjectCacheEnabled = false,
      //OverwriteTranslationsOnChange = false,
      //ResourcePath = new()
      //{
      //  DecodedUrl = "https://mock.sharepoint.com/sites/mockSite"
      //},
      //QuickLaunchEnabled = true,
      //RecycleBinEnabled = true,
      //SearchScope = 0,
      //ServerRelativeUrl = "/sites/mockSite",
      //SiteLogoUrl = null,
      //SyndicationEnabled = true,
      //TenantAdminMembersCanShare = 0,
      Title = "Mock Site",
      //TreeViewEnabled = false,
      //UIVersion = 15,
      //UIVersionConfigurationEnabled = false,
      //Url = "https://mock.sharepoint.com/sites/mockSite",
      //WebTemplate = "SITEPAGEPUBLISHING",
      WelcomePage = "SitePages/This-one-is-not-posted.aspx"
    };

    [Fact]
    public async Task GetAsync()
    {
      // Arrange
      var adapter = Substitute.For<IRequestAdapter>();
      adapter.BaseUrl = mockWebUrl;

      var client = new KiotaSharePointClient(adapter);

      // Return the mocked web
      adapter.SendAsync(
          Arg.Any<RequestInformation>(),
          Arg.Any<ParsableFactory<Web>>(),
          Arg.Any<Dictionary<string, ParsableFactory<IParsable>>>(),
          Arg.Any<CancellationToken>())
          .ReturnsForAnyArgs(mockWeb);

      // Act
      var webRequest = client._api.Web.ToGetRequestInformation();

      var web = await client._api.Web.GetAsync();

      // Assert
      Assert.Equal("{+baseurl}/_api/Web", webRequest.UrlTemplate);

      Assert.NotNull(web);
      Assert.Equal(mockWeb.Title, web.Title);
    }


    //[Fact]
    //public void GeneratesCorrectRequestHeaders()
    //{
    //  // TODO: move this to a base test class...

    //  using HttpResponseMessage response = new HttpResponseMessage();
    //  using GraphServiceTestClient gsc = GraphServiceTestClient.Create(response);

    //  // ACT
    //  var request = gsc.GraphServiceClient
    //                      .SharePointAPI(mockWebUrl)
    //                      .Web
    //                      .Request()
    //                      .GetHttpRequestMessage();

    //  // ASSERT
    //  Assert.Equal(SharePointAPIRequestConstants.Headers.AcceptHeaderValue, request.Headers.Accept.ToString());
    //  Assert.True(request.Headers.Contains(SharePointAPIRequestConstants.Headers.ODataVersionHeaderName), $"Header does not contain {SharePointAPIRequestConstants.Headers.ODataVersionHeaderName} header");
    //  Assert.Equal(SharePointAPIRequestConstants.Headers.ODataVersionHeaderValue, string.Join(',', request.Headers.GetValues(SharePointAPIRequestConstants.Headers.ODataVersionHeaderName)));
    //}

    //[Fact]
    //public async void Get_ReturnsCorrectResponse()
    //{
    //  // ARRANGE
    //  var responseContent = ResourceManager.GetHttpResponseContent("GetWebResponse.json");
    //  var responseMessage = new HttpResponseMessage()
    //  {
    //    StatusCode = HttpStatusCode.OK,
    //    Content = new StringContent(responseContent),
    //  };

    //  using (responseMessage)
    //  using (GraphServiceTestClient gsc = GraphServiceTestClient.Create(responseMessage))
    //  {
    //    // ACT
    //    var actual = await gsc.GraphServiceClient
    //                              .SharePointAPI(mockWebUrl)
    //                              .Web
    //                              .Request()
    //                              .Expand("RegionalSettings,RegionalSettings/TimeZone")
    //                              .GetAsync();

    //    // ASSERT
    //    Assert.Equal("Mock Site", actual.Title);
    //    Assert.Equal("SitePages/This-one-is-not-posted.aspx", actual.WelcomePage);
    //    Assert.NotNull(actual.RegionalSettings);
    //    Assert.Equal(13, actual.RegionalSettings.TimeZone.Id);
    //  }
    //}

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
