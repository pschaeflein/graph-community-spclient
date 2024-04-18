namespace Kiota.SharePoint.MockApi.Models
{
  public class Group : Principal
  {
#nullable enable

    public bool? AllowMembersEditMembership { get; set; }

    public bool? AllowRequestToJoinLeave { get; set; }

    public bool? AutoAcceptRequestToJoinLeave { get; set; }

    public string? Description { get; set; }

    public bool? OnlyAllowMembersViewMembership { get; set; }

    public string? OwnerNavigationLink { get; set; }

    public Principal? Owner { get; set; }

    public string? OwnerTitle { get; set; }

    public string? RequestToJoinLeaveEmailSetting { get; set; }

    public string? UsersNavigationLink { get; set; }

    public List<User>? Users { get; private set; }

#nullable restore

    public Group()
    {
      Users = [];
    }
  }
}
