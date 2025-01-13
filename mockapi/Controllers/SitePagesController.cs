using Graph.Community.SPClient.MockApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graph.Community.SPClient.MockApi.Controllers
{
  [ApiController]
  [Consumes("application/json; odata.metadata=minimal")]
  [Produces("application/json; odata.metadata=minimal")]
  public class SitePagesController : ControllerBase
  {
    [HttpGet("/{serverRelativeSiteUrl}/_api/sitepages/pages")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CollectionResponse<SitePage>))]
    public List<SitePage> GetSitePages(
      [FromRoute] string serverRelativeSiteUrl)
    {
      return new();
    }


    [HttpGet("/{serverRelativeSiteUrl}/_api/sitepages/pages({listItemId})")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SitePage>))]
    public SitePage GetSitePage(
      [FromRoute] string serverRelativeSiteUrl,
      [FromRoute] int listItemId,
      [FromQuery(Name = "$select")] string[] select,
      [FromQuery(Name = "filter")] string[] filter)
    {
      return new();
    }
  }
}
