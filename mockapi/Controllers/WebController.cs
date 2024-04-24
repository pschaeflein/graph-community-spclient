using Graph.Community.MockApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graph.Community.Controllers
{
  [ApiController]
  [Consumes("application/json; odata.metadata=minimal")]
  [Produces("application/json; odata.metadata=minimal")]
  public class WebController : ControllerBase
  {
    [HttpGet("/{serverRelativeSiteUrl}/_api/Web")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Web))]
    public Web GetWeb(
      [FromRoute] string serverRelativeSiteUrl,
      [FromQuery(Name = "$select")] string[] select,
      [FromQuery(Name = "$expand")] string[] expand)
    {
      return new();
    }
  }
}
