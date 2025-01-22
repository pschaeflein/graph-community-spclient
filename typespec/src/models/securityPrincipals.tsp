using TypeSpec.OpenAPI;

namespace Graph.Community;

@discriminator("@odata.type")
model Principal {
  /**
   * The member identifier for the user or group.
   */
  Id?: int32;

  /**
   * Whether this member should be hidden in the UI.
   */
  IsHiddenInUI?: boolean;

  /**
   * A bitwise value containing the type of the principal (SP.PrincipalType):
   *  None = 0
   *  User = 1
   *  DistributionList = 2
   *  SecurityGroup = 4
   *  SharePointGroup = 8
   *  All = 15
   */
  PrincipalType?: int32;

  /**
   * The login name of the user.
   */
  LoginName?: string;

  /**
   * The name of the principal.
   */
  Title?: string;
}

model Group extends Principal {
  "@odata.type": "#SP.Group";

  /**
   * Whether group members can modify membership in the group.
   */
  AllowMembersEditMembership: boolean;

  /**
   * Whether to allow users to request membership in the group and to allow users to request to leave the group.
   */
  AllowRequestToJoinLeave: boolean;

  /**
   * Whether users are automatically added or removed when they make a request.
   */
  AutoAcceptRequestToJoinLeave: boolean;

  /**
   * Description for the group.
   */
  Description: string;

  /**
   * Whether only group members are allowed to view the list of members in the group.
   */
  OnlyAllowMembersViewMembership: boolean;

  /**
   * The owner for the group, which can be a user or another group.
   */
  Owner?: Principal;

  /**
   * The name for the owner of this group
   */
  OwnerTitle: string;

  /**
   * The e-mail address to which membership requests are sent.
   */
  RequestToJoinLeaveEmailSetting: string;

  Users: User[];
}


model User extends Principal{
  "@odata.type": "#SP.User";

  @doc("The e-mail address of the user.")
  Email?:string;

  @doc("Whether the user is a site collection administrator.")
  IsSiteAdmin: boolean;

  @doc("IsEmailAuthenticationGuestUser")
  IsEmailAuthenticationGuestUser: boolean;

  @doc("IsShareByEmailGuestUser")
  IsShareByEmailGuestUser: boolean;

  @doc("UserPrincipalName")
  UserPrincipalName?: string;

  @doc("The user's name identifier and the issuer of the user's name identifier.")
  UserId?: UserId
}

model UserId
{
  @doc("The user's name identifier.")
  NameId?: string;

  @doc("The issuer of the user's name identifier")
  NameIdIssuer?: string;
}
