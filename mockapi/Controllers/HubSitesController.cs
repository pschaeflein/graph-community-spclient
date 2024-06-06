using Graph.Community.SPClient.MockApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graph.Community.SPClient.MockApi.Controllers
{
  [ApiController]
  [Consumes("application/json; odata.metadata=minimal")]
  [Produces("application/json; odata.metadata=minimal")]
  public class HubSitesController : ControllerBase
  {
    [HttpGet("/{serverRelativeSiteUrl}/_api/HubSites")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CollectionResponse<HubSite>))]
    public CollectionResponse<HubSite> GetHubSites([FromRoute] string serverRelativeSiteUrl)
    {
      return new();
    }
  }
}
