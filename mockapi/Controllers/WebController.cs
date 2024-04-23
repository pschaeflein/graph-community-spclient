using Graph.Community.MockApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graph.Community.Controllers
{
  [ApiController]
  [Consumes("application/json")]
  [Produces("application/json")]
  public class WebController : ControllerBase
  {
    [HttpGet("/{serverRelativeSiteUrl}/_api/Web")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Web))]
    public Web GetWeb(string serverRelativeSiteUrl)
    {
      return new();
    }
  }
}
