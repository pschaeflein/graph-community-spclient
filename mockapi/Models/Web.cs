namespace Kiota.SharePoint.MockApi.Models
{
  public class Web
  {
    public string? Id { get; set; }     

    public string? Title { get; set; }

    public ChangeToken? CurrentChangeToken { get; set; }

    public bool? FooterEnabled { get; set; }

    public FooterLayoutType? FooterLayout { get; set; }

    public string? UsersNavigationLink { get; set; }

    public List<User>? Users { get; private set; }

    public string? AssociatedMemberGroupNavigationLink { get; set; }

    public Group? AssociatedMemberGroup { get; set; }

    public string? AssociatedOwnerGroupNavigationLink { get; set; }

    public Group? AssociatedOwnerGroup { get; set; }

    public string? AssociatedVisitorGroupNavigationLink { get; set; }

    public Group? AssociatedVisitorGroup { get; set; }

    public string? WelcomePage { get; set; }

    public RegionalSettings? RegionalSettings { get; set; }

    public Web()
    {
      Users = [];
    }
  }
}

