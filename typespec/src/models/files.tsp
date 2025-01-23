import "@typespec/http";
import "./common.tsp";
import "./securityPrincipals.tsp";

using TypeSpec.Http;

namespace Graph.Community;

/**
 * Basic information about a file.
 * (To get complete information, use the Microsoft Graph endpoint.)
 */
model File {
  CheckedOutByUser: User;
  CheckInComment: string;

  /**
   * A value that indicates how the file is checked out of a document library. Represents an SP.CheckOutType value: Online = 0; Offline = 1; None = 2.
   */
  CheckOutType: int32;

  /**
   * A value that specifies the customization status of the file. Represents an SP.CustomizedPageStatus value: None = 0; Uncustomized = 1; Customized = 2
   */
  CustomizedPageStatus: int32;

  Exists: boolean;

  /**
   * A value that specifies the publishing level of the file. Represents an SP.FileLevel value: Published = 1; Draft = 2; Checkout = 255.
   */
  Level: int32;

  LockedByUser: User;
  MajorVersion: int32;
  MinorVersion: int32;
  Name: string;
  ServerRelativeUrl: string;
  TimeCreated: utcDateTime;
  TimeLastModified: utcDateTime;
  Title: string;
  UIVersionLabel: string;

  @format("uuid")
  UniqueId: string;
}
