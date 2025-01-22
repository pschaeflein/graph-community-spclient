import "@typespec/http";
import "./common.tsp";

using TypeSpec.Http;

namespace Graph.Community;

model HubSite {
  /**
   * Identifies the hub site.
  */
  @format("uuid")
  ID: string;

  /**
   * The display name of the hub site.
   */
  Title?: string;

  /**
   * ID of the hub parent site.
   */
  @format("uuid")
  SiteId: string;

  /**
   * The tenant instance ID in which the hub site is located. Use empty GUID for the default tenant instance.
   */
  @format("uuid")
  TenantInstanceId: string;

  /**
   * URL of the hub parent site.
   */
  SiteUrl?: string;

  /**
   * The URL of a logo to use in the hub site navigation.
   */
  LogoUrl?: string;

  /**
   * A description of the hub site.
   */
  Description?: string;

  /**
   * List of security groups with access to join the hub site. Null if everyone has permission.
   */
  Targets: string;
}

model HubSiteCollection {
  ...OkResponse;
  ...Body<CollectionResponse<HubSite>>;
}
