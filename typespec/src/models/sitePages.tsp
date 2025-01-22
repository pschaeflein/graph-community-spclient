import "@typespec/http";
import "./common.tsp";

using TypeSpec.Http;

namespace Graph.Community;

model SitePage {
  Id: int32;
  Title?: string;
  Description?: string;

  /**
   * Promoted state:
   *  NotPromoted = 0,
   *  PromoteOnPublish = 1,
   *  Promoted = 2
   */
  PromotedState: int32;

  FirstPublished?: utcDateTime;
  Modified?: utcDateTime;
  FileName?: string;
  AbsoluteUrl?: string;
  BannerImageUrl?: string;
  BannerThumbnailUrl?: string;

  /**
   * Site-relative Url
   */
  Url?: string;

  @format("uuid")
  UniqueId?: string;

  ContentTypeId?: string;
  IsWebWelcomePage: boolean;
  PageLayoutType?: string;

  /**
   * Created by user information.
   * @remarks Only included when the $expand query parameter is used.
   */
  CreatedBy: PublishingUserInfo;

  /**
   * Last modified by user information.
   * @remarks Only included when the $expand query parameter is used.
   */
  LastModifiedBy: PublishingUserInfo;
}

model PublishingUserInfo {
  AccountName: string;
  Acronym: string;
  Color: string;
  Name: string;
}

model SPSitePagesCollectionResponse {
  ...OkResponse;
  ...Body<CollectionResponse<SitePage>>;
}
