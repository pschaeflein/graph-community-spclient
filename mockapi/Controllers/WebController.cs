using Kiota.SharePoint.MockApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kiota.SharePoint.MockApi.Controllers
{
  [ApiController]
  public class WebController : ControllerBase
  {
    [HttpGet("_api/Web")]
    public Web GetWeb()
    {
      return new();
    }
  }
}
