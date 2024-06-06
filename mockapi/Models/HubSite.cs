using System.Text.Json.Serialization;

namespace Graph.Community.SPClient.MockApi.Models
{
  public class HubSite
  {
    /// <summary>
    /// Identifies the hub site.
    /// </summary>
    [JsonPropertyName("ID")]
    public Guid ID { get; set; }

    /// <summary>
    /// The display name of the hub site.
    /// </summary>
    [JsonPropertyName("Title")]
    public string? Title { get; set; }

    /// <summary>
    /// ID of the hub parent site.
    /// </summary>
    [JsonPropertyName("SiteId")]
    public Guid SiteId { get; set; }

    /// <summary>
    /// The tenant instance ID in which the hub site is located.Use empty GUID for the default tenant instance.
    /// </summary>
    [JsonPropertyName("TenantInstanceId")]
    public Guid TenantInstanceId { get; set; }

    /// <summary>
    /// URL of the hub parent site.
    /// </summary>
    [JsonPropertyName("SiteUrl")]
    public string? SiteUrl { get; set; }

    /// <summary>
    /// The URL of a logo to use in the hub site navigation.
    /// </summary>
    [JsonPropertyName("LogoUrl")]
    public string? LogoUrl { get; set; }

    /// <summary>
    /// A description of the hub site.
    /// </summary>
    [JsonPropertyName("Description")]
    public string? Description { get; set; }

    /// <summary>
    /// List of security groups with access to join the hub site. Null if everyone has permission.
    /// </summary>
    [JsonPropertyName("Targets")]
    public string? Targets { get; set; }
  }
}
