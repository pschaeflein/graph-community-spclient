using System.Text.Json.Serialization;

namespace Graph.Community.MockApi.Models
{
  public class Group : Principal
  {
#nullable enable

    [JsonPropertyName("AllowMembersEditMembership")]
    public bool? AllowMembersEditMembership { get; set; }

    [JsonPropertyName("AllowRequestToJoinLeave")]
    public bool? AllowRequestToJoinLeave { get; set; }

    [JsonPropertyName("AutoAcceptRequestToJoinLeave")]
    public bool? AutoAcceptRequestToJoinLeave { get; set; }

    [JsonPropertyName("Description")]
    public string? Description { get; set; }

    [JsonPropertyName("OnlyAllowMembersViewMembership")]
    public bool? OnlyAllowMembersViewMembership { get; set; }

    [JsonPropertyName("OwnerNavigationLink")]
    public string? OwnerNavigationLink { get; set; }

    [JsonPropertyName("Owner")]
    public Principal? Owner { get; set; }

    [JsonPropertyName("OwnerTitle")]
    public string? OwnerTitle { get; set; }

    [JsonPropertyName("RequestToJoinLeaveEmailSetting")]
    public string? RequestToJoinLeaveEmailSetting { get; set; }

    [JsonPropertyName("UsersNavigationLink")]
    public string? UsersNavigationLink { get; set; }

    [JsonPropertyName("Users")]
    public List<User>? Users { get; private set; }

#nullable restore

    public Group()
    {
      Users = [];
    }
  }
}
