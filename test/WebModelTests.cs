#nullable disable

using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;

namespace Graph.Community.Tests
{
  public class WebModelTests(WebModelFixture fixture) : IClassFixture<WebModelFixture>
  {
    readonly WebModelFixture fixture = fixture;

    [Fact]
    public void DeserializeWeb()
    {
      // ARRANGE

      // ACT
      var actual = fixture.Web;

      // ASSERT
      Assert.Equal("b3bb5585-bb7b-4fba-8619-a2bcfa2ff24e", actual.Id);
      Assert.Equal("Mock Site", actual.Title);
      Assert.Equal("1;2;b3bb5585-bb7b-4fba-8619-a2bcfa2ff24e;637908031948500000;353893883", actual.CurrentChangeToken.StringValue);
      Assert.True(actual.FooterEnabled);
      Assert.Equal("SitePages/This-one-is-not-posted.aspx", actual.WelcomePage);
      Assert.NotEmpty(actual.AdditionalData);
      Assert.Single(actual.UserCustomActions);
    }

    [Fact]
    public void DeserializeRegionalSettings()
    {
      // ARRANGE

      // ACT
      var actual = fixture.RegionalSettings;

      // ASSERT
      Assert.Equal(0, actual.AdjustHijriDays);
      Assert.Equal(0, actual.AlternateCalendarType);
      Assert.Equal("AM", actual.AM);
      Assert.Equal(1, actual.CalendarType);
      Assert.Equal(25, actual.Collation);
      Assert.Equal(2070, actual.CollationLCID);
      Assert.Equal(0, actual.DateFormat);
      Assert.Equal("/", actual.DateSeparator);
      Assert.Equal(".", actual.DecimalSeparator);
      Assert.Equal("3;0", actual.DigitGrouping);
      Assert.Equal(0, actual.FirstDayOfWeek);
      Assert.Equal(0, actual.FirstWeekOfYear);
      Assert.False(actual.IsEastAsia);
      Assert.False(actual.IsRightToLeft);
      Assert.False(actual.IsUIRightToLeft);
      Assert.Equal(",", actual.ListSeparator);
      Assert.Equal(1033, actual.LocaleId);
      Assert.Equal("-", actual.NegativeSign);
      Assert.Equal(1, actual.NegNumberMode);
      Assert.Equal("PM", actual.PM);
      Assert.Equal("", actual.PositiveSign);
      Assert.False(actual.ShowWeeks);
      Assert.Equal(",", actual.ThousandSeparator);
      Assert.False(actual.Time24);
      Assert.Equal(0, actual.TimeMarkerPosition);
      Assert.Equal(":", actual.TimeSeparator);
      Assert.Equal(1020, actual.WorkDayEndHour);
      Assert.Equal(62, actual.WorkDays);
      Assert.Equal(480, actual.WorkDayStartHour);
    }

    [Fact]
    public void DeserializeTimeZone()
    {
      // ARRANGE

      // ACT
      var actual = fixture.TimeZone;

      // ASSERT
      Assert.Equal("(UTC-6) Central Time (US and Canada)", actual.Description);
      Assert.Equal(2, actual.Id);
      Assert.Equal(-360, actual.Information.Bias);
      Assert.Equal(-300, actual.Information.DaylightBias);
      Assert.Equal(-360, actual.Information.StandardBias);
    }

    [Fact]
    public void DeserializeAssociatedGroup()
    {
      // ARRANGE

      // ACT
      var actual = fixture.SiteGroup;

      // ASSERT
      Assert.True(actual.AllowMembersEditMembership);
      Assert.False(actual.AllowRequestToJoinLeave);
      Assert.False(actual.AutoAcceptRequestToJoinLeave);
      Assert.Null(actual.Description);
      Assert.False(actual.OnlyAllowMembersViewMembership);
      Assert.Equal("Mock site Owners", actual.OwnerTitle);
      Assert.Equal("", actual.RequestToJoinLeaveEmailSetting);
    }

    [Fact]
    public void DeserializeGroupOwnerAsUser()
    {
      // ARRANGE

      // ACT
      var actual = fixture.SiteGroupOwnedByUser;
      var actualOwnerUser = actual.Owner as User;

      // ASSERT
      Assert.IsType<User>(actual.Owner);
      Assert.False(actual.Owner.IsHiddenInUI);
      Assert.Equal(1, actual.Owner.PrincipalType);
      Assert.Equal("i:0#.f|membership|paul@mock.sharepoint.com", actual.Owner.LoginName);
      Assert.Equal("Paul", actual.Owner.Title);

      Assert.Equal("paul@mock.sharepoint.com", actualOwnerUser.Email);
      Assert.True(actualOwnerUser.IsSiteAdmin);
      Assert.False(actualOwnerUser.IsEmailAuthenticationGuestUser);
      Assert.False(actualOwnerUser.IsShareByEmailGuestUser);
      Assert.Equal("paul@mock.sharepoint.com", actualOwnerUser.UserPrincipalName);

      Assert.Equal("1003200040040c84", actualOwnerUser.UserId.NameId);
      Assert.Equal("urn:federation:microsoftonline", actualOwnerUser.UserId.NameIdIssuer);
    }

    [Fact]
    public void DeserializeGroupOwnerAsGroup()
    {
      // ARRANGE

      // ACT
      var actual = fixture.SiteGroupOwnedByGroup;
      var actualOwnerGroup = actual.Owner as Group;

      // ASSERT
      Assert.IsType<Group>(actual.Owner);
      Assert.False(actual.Owner.IsHiddenInUI);
      Assert.Equal(8, actual.Owner.PrincipalType);
      Assert.Equal("Mock site Owners", actual.Owner.LoginName);
      Assert.Equal("Mock site Owners", actual.Owner.Title);
      
      Assert.False(actualOwnerGroup.AllowMembersEditMembership);
      Assert.False(actualOwnerGroup.AllowRequestToJoinLeave);
      Assert.False(actualOwnerGroup.AutoAcceptRequestToJoinLeave);
      Assert.Null(actualOwnerGroup.Description);
      Assert.False(actualOwnerGroup.OnlyAllowMembersViewMembership);
      Assert.Equal("", actualOwnerGroup.RequestToJoinLeaveEmailSetting);
      Assert.Equal("Mock site Owners", actualOwnerGroup.OwnerTitle);
    }

    [Fact]  
    public void DeserializeUserCustomAction()
    {
      // ARRANGE

      // ACT
      var actual = fixture.UserCustomActions;

      // ASSERT
      Assert.Equal(new("e792b1a3-dff4-49ea-921d-139196e7faad"), actual.ClientSideComponentId);
      Assert.Equal("{\"configFlags\":{}}", actual.ClientSideComponentProperties);
      Assert.Null(actual.CommandUIExtension);
      Assert.Null(actual.Description);
      Assert.Null(actual.Group);
      Assert.Equal("{}", actual.HostProperties);
      Assert.Equal(new("a425d3a7-7523-4722-a12e-e8e2a12f5aa8"), actual.Id);
      Assert.Null(actual.ImageUrl);
      Assert.Equal("ClientSideExtension.ApplicationCustomizer", actual.Location);
      Assert.Equal("{a425d3a7-7523-4722-a12e-e8e2a12f5aa8}", actual.Name);
      Assert.Null(actual.RegistrationId);
      Assert.Equal(0, actual.RegistrationType);
      Assert.Equal(3, actual.Scope);
      Assert.Null(actual.ScriptBlock );
      Assert.Null(actual.ScriptSrc );
      Assert.Equal(65536, actual.Sequence);
      Assert.Equal("MockAction", actual.Title );
      Assert.Null(actual.Url );
      Assert.Equal("9.9.12.1", actual.VersionOfUserCustomAction );

    }

  }

  public class WebModelFixture : IDisposable
  {
    public Web Web { get; private set; }
    public RegionalSettings RegionalSettings { get; private set; }
    public TimeZoneObject TimeZone { get; private set; }
    public Group SiteGroup { get; private set; }
    public Group SiteGroupOwnedByUser { get; private set; }
    public Group SiteGroupOwnedByGroup { get; private set; }
    public UserCustomAction UserCustomActions { get; private set; }

    public WebModelFixture()
    {
      // initialize the fixture
      Stream resourceStream;
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      resourceStream = ResourceManager.GetEmbeddedResource("SP.Web.json");
      Web = KiotaJsonSerializer.DeserializeAsync<Web>(resourceStream).GetAwaiter().GetResult();

      resourceStream = ResourceManager.GetEmbeddedResource("SP.RegionalSettings.json");
      RegionalSettings = KiotaJsonSerializer.DeserializeAsync<RegionalSettings>(resourceStream).GetAwaiter().GetResult();

      resourceStream = ResourceManager.GetEmbeddedResource("SP.TimeZone.json");
      TimeZone = KiotaJsonSerializer.DeserializeAsync<TimeZoneObject>(resourceStream).GetAwaiter().GetResult();

      resourceStream = ResourceManager.GetEmbeddedResource("SP.Group.json");
      SiteGroup = KiotaJsonSerializer.DeserializeAsync<Group>(resourceStream).GetAwaiter().GetResult();

      resourceStream = ResourceManager.GetEmbeddedResource("SP.GroupOwnedByUser.json");
      SiteGroupOwnedByUser = KiotaJsonSerializer.DeserializeAsync<Group>(resourceStream).GetAwaiter().GetResult();

      resourceStream = ResourceManager.GetEmbeddedResource("SP.GroupOwnedByGroup.json");
      SiteGroupOwnedByGroup = KiotaJsonSerializer.DeserializeAsync<Group>(resourceStream).GetAwaiter().GetResult();

      resourceStream = ResourceManager.GetEmbeddedResource("SP.UserCustomAction.json");
      UserCustomActions = KiotaJsonSerializer.DeserializeAsync<UserCustomAction>(resourceStream).GetAwaiter().GetResult();
    }

    public void Dispose()
    {
      // clean up the fixture

      GC.SuppressFinalize(this);
    }
  }
}
