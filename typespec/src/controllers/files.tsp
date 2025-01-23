import "@typespec/http";
import "@typespec/rest";
import "@typespec/openapi3";

import "../models/files.tsp";

using TypeSpec.Http;
namespace Graph.Community;

@tag("Web")
@route("/{serverRelativeSiteUrl}/_api/web/GetFileById('{id}')")
op GetFileById(
  /**
   * The Id of the file.
   */
  @path
  @format("uuid")
  id: string,
  ...CommonParameters,
  ...ODataSelectParameter,
  ...ODataExpandParameter,
): File;

@tag("Web")
@route("/{serverRelativeSiteUrl}/_api/web/GetFileByServerRelativePath(DecodedUrl=@path)")
op GetFileByServerRelativePath(
  /**
   * Server-relative path to the file.
   */
  @query
  "@path": string,
  ...ODataSelectParameter,
  ...ODataExpandParameter,
  ...CommonParameters,
): File;
