import "@typespec/http";
import "@typespec/rest";
import "@typespec/openapi";
import "@typespec/openapi3";

import "./controllers/files.tsp";
import "./controllers/hubSites.tsp";
import "./controllers/lists.tsp";
import "./controllers/sitePages.tsp";
import "./controllers/web.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

@service({
  title: "Graph.Community SDK for Microsoft SharePoint REST API",
  version: "5.2.1",
})
@tagMetadata(
  "Hub sites",
  #{
    description: "Hub sites REST API",
    externalDocs: #{
      url: "https://learn.microsoft.com/en-us/sharepoint/dev/features/hub-site/rest-hubsites-method",
    },
  }
)
// @tagMetadata(
//   "Files",
//   #{
//     description: "Methods for working with files and folders.",
//     externalDocs: #{
//       url: "https://learn.microsoft.com/en-us/sharepoint/dev/sp-add-ins/working-with-folders-and-files-with-rest",
//     },
//   }
// )
@tagMetadata(
  "Lists",
  #{
    description: "Methods for reading Lists and their properties.",
    externalDocs: #{
      url: "https://learn.microsoft.com/en-us/sharepoint/dev/sp-add-ins/working-with-lists-and-list-items-with-rest",
    },
  }
)
@tagMetadata(
  "Site Pages",
  #{
    description: "Web",
    externalDocs: #{
      url: "https://pnp.github.io/cli-microsoft365/cmd/spo/page/page-list",
    },
  }
)
@tagMetadata(
  "Web",
  #{
    description: "Methods for working with the Web resource.",
    externalDocs: #{
      url: "https://learn.microsoft.com/en-us/sharepoint/dev/sp-add-ins/determine-sharepoint-rest-service-endpoint-uris?tabs=http",
    },
  }
)
namespace Graph.Community {}
