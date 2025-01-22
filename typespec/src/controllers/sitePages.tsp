import "@typespec/http";
import "@typespec/rest";
import "@typespec/openapi3";

import "../models/sitePages.tsp";

using TypeSpec.Http;

namespace Graph.Community;

@tag("Site Pages")
@route("/{serverRelativeSiteUrl}/_api/SitePages")
op GetSitePages(
  ...ODataSelectParameter,
  ...CommonParameters,
): SPSitePagesCollectionResponse;

@tag("Site Pages")
@route("/{serverRelativeSiteUrl}/_api/SitePages/{id}")
op GetSitePage(
  @path id: int32,
  ...ODataSelectParameter,
  ...ODataExpandParameter,
  ...CommonParameters,
): SitePage;
