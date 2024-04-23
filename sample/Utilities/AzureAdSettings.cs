namespace Graph.Community.SPClient.Sample
{
  public class AzureAdSettings
  {
    public const string ConfigurationSectionName = "AzureAd";
    public required string TenantId { get; set; }
    public required string ClientId { get; set; }
  }
}
