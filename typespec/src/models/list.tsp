import "@typespec/http";
import "./common.tsp";

using TypeSpec.Http;

namespace Graph.Community;

/**
 * Basic information about a list.
 * (To get complete information, use the Microsoft Graph endpoint.)
 */
model List {
  /**
   * The GUID that identifies the list in the database.
   */
  @format("uuid")
  Id: string;

  /**
   * The displayed title for the list.
   */
  Title?: string;

  /**
   * The list definition type on which the list is based.
   */
  BaseTemplate?: int32;

  Forms?: Form[];
}

model Form {
  Id: string;

  /**
   *  Invalid = -1,
   *  DefaultView = 0,
   *  NormalView = 1,
   *  DialogView = 2,
   *  View = 3,
   *  DisplayForm = 4,
   *  DisplayFormDialog = 5,
   *  EditForm = 6,
   *  EditFormDialog = 7,
   *  NewForm = 8,
   *  NewFormDialog = 9,
   *  SolutionForm = 10,
   *  PAGE_MAXITEMS = 11
   */
  FormType: int32;
  ServerRelativeUrl: string;
}

model SPListResponse {
  ...OkResponse;
  ...Body<List>;
}

model SPListCollectionResponse {
  ...OkResponse;
  ...Body<CollectionResponse<List>>;
}

