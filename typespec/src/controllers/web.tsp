import "@typespec/http";
import "@typespec/rest";
import "@typespec/openapi3";

import "../models/web.tsp";

using TypeSpec.Http;

namespace Graph.Community;

@tag("Web")
@route("/{serverRelativeSiteUrl}/_api/web")
op GetWeb(
  ...CommonParameters,
  ...ODataSelectParameter,
  ...ODataExpandParameter,
): SPWebResponse;
