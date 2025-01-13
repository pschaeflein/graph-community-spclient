using System.Text.Json.Serialization;

namespace Graph.Community.SPClient.MockApi.Models
{
  [AllowAdditionalProperties()]
  public class SitePage
  {
    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [JsonPropertyName("Title")]
    public string? Title { get; set; }

    [JsonPropertyName("PromotedState")]
    public SitePagePromotedState PromotedState { get; set; }

    [JsonPropertyName("FirstPublished")]
    public DateTimeOffset? FirstPublishedDateTime
    {
      get
      {
        //      "FirstPublished": "0001-01-01T08:00:00Z",
        if (firstPublished.HasValue && firstPublished.Value == SitePage.NULL_PUBLISHED_DATE)
        {
          return null;
        }
        return firstPublished;
      }
      set
      {
        firstPublished = value;
      }
    }
    private DateTimeOffset? firstPublished;
    private static readonly DateTimeOffset NULL_PUBLISHED_DATE = new(0001, 01, 01, 08, 00, 00, TimeSpan.Zero);

    [JsonPropertyName("Modified")]
    public DateTimeOffset? LastModifiedDateTime { get; set; }

    [JsonPropertyName("FileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("AbsoluteUrl")]
    public string? AbsoluteUrl { get; set; }

    [JsonPropertyName("BannerImageUrl")]
    public string? BannerImageUrl { get; set; }

    [JsonPropertyName("BannerThumbnailUrl")]
    public string? BannerThumbnailUrl { get; set; }

    [JsonPropertyName("Url")]
    public string? SiteRelativeUrl { get; set; }

    [JsonPropertyName("UniqueId")]
    public Guid UniqueId { get; set; }

    [JsonPropertyName("ContentTypeId")]
    public string? ContentTypeId { get; set; }

    [JsonPropertyName("IsWebWelcomePage")]
    public bool IsWebWelcomePage { get; set; }

    [JsonPropertyName("PageLayoutType")]
    public string? PageLayoutType { get; set; }
  }
}
