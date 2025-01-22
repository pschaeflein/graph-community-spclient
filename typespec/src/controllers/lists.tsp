import "@typespec/http";
import "@typespec/rest";
import "@typespec/openapi3";

import "../models/list.tsp";

using TypeSpec.Http;
namespace Graph.Community;

@tag("Lists")
@route("/{serverRelativeSiteUrl}/_api/web/lists")
/**
 * Returns basic information about all lists in the site. (To get complete information, use the Microsoft Graph endpoint.)
 */
op GetLists(
  ...CommonParameters,
  ...ODataSelectParameter,
): SPListCollectionResponse;

@tag("Lists")
@route("/{serverRelativeSiteUrl}/_api/web/lists/{id}")
op GetList(
  /**
   * The Id of the list.
   */
  @path
  @format("uuid")
  id: string,
  ...ODataSelectParameter,
  ...ODataExpandParameter,
  ...CommonParameters,
): SPListResponse;
