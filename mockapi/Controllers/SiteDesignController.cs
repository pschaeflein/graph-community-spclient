using Graph.Community.SPClient.MockApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Graph.Community.SPClient.MockApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SiteDesignController
  {
    [HttpPost("/{serverRelativeSiteUrl}/_api/Microsoft.Sharepoint.Utilities.WebTemplateExtensions.SiteScriptUtility.GetSiteDesignMetadata")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CollectionResponse<SiteDesignMetadata>))]
    public SiteDesignMetadata GetById(
      [FromRoute] string serverRelativeSiteUrl,
      GetSiteDesignMetadataRequest request)
    {
      return new();
    }

    //public IApplySiteDesignActionOutcomeCollectionPage Apply()
    //{    }

    //public SiteDesignMetadata Create()
    //{ }
  }
}
