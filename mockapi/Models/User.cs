namespace Kiota.SharePoint.MockApi.Models
{
  public class User : Principal
  {
#nullable enable

    public string? Email { get; set; }

    /// <summary>Gets or sets a Boolean value that specifies whether the user is a site collection administrator.</summary>
    public bool? IsSiteAdmin { get; set; }

    public bool? IsEmailAuthenticationGuestUser { get; set; }

    public bool? IsShareByEmailGuestUser { get; set; }

    public string? UserPrincipalName { get; set; }

    public UserId? UserId { get; set; }

#nullable restore

  }

  public class UserId
  {
    public string? NameId { get; set; }

    public string? NameIdIssuer { get; set; }
  }
}
