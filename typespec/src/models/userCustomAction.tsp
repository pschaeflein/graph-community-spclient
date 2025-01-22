namespace Graph.Community;

model UserCustomAction {
  @format("uuid")
  ClientSideComponentId: string;

  ClientSideComponentProperties?: string;

  /**
   * A value that specifies an implementation specific XML fragment that determines user interface properties of the custom action.
   */
  CommandUIExtension?: string;

  /**
   * The description of the custom action.
   */
  Description?: string;

  /**
   * A value that specifies an implementation-specific value that determines the position of the custom action in the page.
   */
  Group?: string;

  HostProperties?: string;

  /**
   * The identifier of the custom action.
   */
  @format("uuid")
  Id: string;

  /**
   * The URL of the image associated with the custom action.
   */
  ImageUrl?: string;

  /**
   * The location of the custom action.
   */
  Location?: string;

  /**
   * The name of the custom action.
   */
  Name?: string;

  /**
   * The value that specifies the identifier of the object associated with the custom action.
   */
  RegistrationId?: string;

  /**
   * The value that specifies the type of object associated with the custom action.
   *
   *   None:0,
   *   List:1,
   *   ContentType:2,
   *   ProgId:3,
   *   FileType:4,
   */
  RegistrationType: int32;

  /**
   * A value that specifies the scope of the custom action.
   * - Unknown = 0,
   * - Site = 2,
   * - Web = 3,
   * - List = 4,
   */
  Scope: int32;

  /**
   * The value that specifies the ECMAScript to be executed when the custom action is performed.
   */
  ScriptBlock?: string;

  /**
   * A value that specifies the URI of a file which contains the ECMAScript to execute on the page.
   */
  ScriptSrc?: string;

  /**
   * The value that specifies an implementation-specific value that determines the order of the custom action that appears on the page.
   */
  Sequence: int32;

  /**
   * The display title of the custom action.
   */
  Title?: string;

  /**
   * The URL, URI, or ECMAScript (JScript, JavaScript) function associated with the action.
   */
  Url?: string;

  /**
   * A value that specifies an implementation specific version identifier.
   */
  VersionOfUserCustomAction?: string;
}
