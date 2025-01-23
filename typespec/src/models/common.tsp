import "@typespec/http";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace Graph.Community;

model CollectionResponse<Item> {
  value: Item[];
}

model CommonParameters {
  /**
   * OData version. (Added automatically by the Graph.Community.SPClient SDK.)
   */
  @header
  odataVersion: "4.0";

  /**
   * The server-relative URL of the site.
   */
  @path
  serverRelativeSiteUrl: string;
}

model ODataSelectParameter {
  /**
   * OData system query option $select.
   */
  @query(#{ explode: false })
  $select?: string[];
}

model ODataExpandParameter {
  /**
   * OData system query option $expand.
   */
  @query(#{ explode: false })
  $expand?: string[];
}
