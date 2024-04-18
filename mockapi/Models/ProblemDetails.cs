using System;

namespace Kiota.SharePoint.MockApi.Models
{
  public class ProblemDetails
  {
#nullable enable

    /// <summary>The detail property</summary>
    public string? Detail { get; set; }

    /// <summary>The instance property</summary>
    public string? Instance { get; set; }

    /// <summary>The primary error message.</summary>
    public string? Message { get; }

    /// <summary>The status property</summary>
    public int? Status { get; set; }

    /// <summary>The title property</summary>
    public string? Title { get; set; }

    /// <summary>The type property</summary>
    public string? Type { get; set; }

#nullable restore

  }
}
