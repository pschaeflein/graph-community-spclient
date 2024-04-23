using System.Text.Json.Serialization;

namespace Graph.Community.MockApi.Models
{
  [AllowAdditionalProperties()]
  public class Web
  {
    [JsonPropertyName("Id")]
    public string? Id { get; set; }     

    [JsonPropertyName("Title")]
    public string? Title { get; set; }

    [JsonPropertyName("CurrentChangeToken")]
    public ChangeToken? CurrentChangeToken { get; set; }

    [JsonPropertyName("FooterEnabled")]
    public bool? FooterEnabled { get; set; }

    [JsonPropertyName("FooterLayout")]
    public FooterLayoutType? FooterLayout { get; set; }

    [JsonPropertyName("UsersNavigationLink")]
    public string? UsersNavigationLink { get; set; }

    [JsonPropertyName("Users")]
    public List<User>? Users { get; private set; }

    [JsonPropertyName("AssociatedMemberGroupNavigationLink")]
    public string? AssociatedMemberGroupNavigationLink { get; set; }

    [JsonPropertyName("AssociatedMemberGroup")]
    public Group? AssociatedMemberGroup { get; set; }

    [JsonPropertyName("AssociatedOwnerGroupNavigationLink")]
    public string? AssociatedOwnerGroupNavigationLink { get; set; }

    [JsonPropertyName("AssociatedOwnerGroup")]
    public Group? AssociatedOwnerGroup { get; set; }

    [JsonPropertyName("AssociatedVisitorGroupNavigationLink")]
    public string? AssociatedVisitorGroupNavigationLink { get; set; }

    [JsonPropertyName("AssociatedVisitorGroup")]
    public Group? AssociatedVisitorGroup { get; set; }

    [JsonPropertyName("WelcomePage")]
    public string? WelcomePage { get; set; }

    [JsonPropertyName("RegionalSettings")]
    public RegionalSettings? RegionalSettings { get; set; }

    public Web()
    {
      Users = [];
    }
  }
}

