namespace Graph.Community.SPClient.Sample
{
  public class SharePointSettings
  {
    public const string ConfigurationSectionName = "SharePoint";

    public required string SpoTenantUrl { get; set; }
    public required string ServerRelativeSiteUrl { get; set; }
    public string? EnsureUserUPN { get; set; }
  }
}
