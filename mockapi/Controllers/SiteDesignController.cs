using Kiota.SharePoint.MockApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kiota.SharePoint.MockApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SiteDesignController
  {
    [HttpPost("/_api/Microsoft.Sharepoint.Utilities.WebTemplateExtensions.SiteScriptUtility.GetSiteDesignMetadata")]
    public SiteDesignMetadata GetById(GetSiteDesignMetadataRequest request)
    {
      return new();
    }

    //public IApplySiteDesignActionOutcomeCollectionPage Apply()
    //{    }

    //public SiteDesignMetadata Create()
    //{ }
  }
}
