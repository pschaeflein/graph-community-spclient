// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Kiota.SharePoint.Client.Models {
    public class Group : IParsable 
    {
        /// <summary>The allowMembersEditMembership property</summary>
        public bool? AllowMembersEditMembership { get; set; }
        /// <summary>The allowRequestToJoinLeave property</summary>
        public bool? AllowRequestToJoinLeave { get; set; }
        /// <summary>The autoAcceptRequestToJoinLeave property</summary>
        public bool? AutoAcceptRequestToJoinLeave { get; set; }
        /// <summary>The description property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description { get; set; }
#nullable restore
#else
        public string Description { get; set; }
#endif
        /// <summary>The id property</summary>
        public int? Id { get; set; }
        /// <summary>The isHiddenInUI property</summary>
        public bool? IsHiddenInUI { get; set; }
        /// <summary>The loginName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? LoginName { get; set; }
#nullable restore
#else
        public string LoginName { get; set; }
#endif
        /// <summary>The onlyAllowMembersViewMembership property</summary>
        public bool? OnlyAllowMembersViewMembership { get; set; }
        /// <summary>The owner property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Principal? Owner { get; set; }
#nullable restore
#else
        public Principal Owner { get; set; }
#endif
        /// <summary>The ownerNavigationLink property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OwnerNavigationLink { get; set; }
#nullable restore
#else
        public string OwnerNavigationLink { get; set; }
#endif
        /// <summary>The ownerTitle property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OwnerTitle { get; set; }
#nullable restore
#else
        public string OwnerTitle { get; set; }
#endif
        /// <summary>The principalType property</summary>
        public int? PrincipalType { get; set; }
        /// <summary>The requestToJoinLeaveEmailSetting property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RequestToJoinLeaveEmailSetting { get; set; }
#nullable restore
#else
        public string RequestToJoinLeaveEmailSetting { get; set; }
#endif
        /// <summary>The title property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Title { get; set; }
#nullable restore
#else
        public string Title { get; set; }
#endif
        /// <summary>The users property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<User>? Users { get; private set; }
#nullable restore
#else
        public List<User> Users { get; private set; }
#endif
        /// <summary>The usersNavigationLink property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? UsersNavigationLink { get; set; }
#nullable restore
#else
        public string UsersNavigationLink { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Group"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Group CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Group();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"allowMembersEditMembership", n => { AllowMembersEditMembership = n.GetBoolValue(); } },
                {"allowRequestToJoinLeave", n => { AllowRequestToJoinLeave = n.GetBoolValue(); } },
                {"autoAcceptRequestToJoinLeave", n => { AutoAcceptRequestToJoinLeave = n.GetBoolValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"id", n => { Id = n.GetIntValue(); } },
                {"isHiddenInUI", n => { IsHiddenInUI = n.GetBoolValue(); } },
                {"loginName", n => { LoginName = n.GetStringValue(); } },
                {"onlyAllowMembersViewMembership", n => { OnlyAllowMembersViewMembership = n.GetBoolValue(); } },
                {"owner", n => { Owner = n.GetObjectValue<Principal>(Principal.CreateFromDiscriminatorValue); } },
                {"ownerNavigationLink", n => { OwnerNavigationLink = n.GetStringValue(); } },
                {"ownerTitle", n => { OwnerTitle = n.GetStringValue(); } },
                {"principalType", n => { PrincipalType = n.GetIntValue(); } },
                {"requestToJoinLeaveEmailSetting", n => { RequestToJoinLeaveEmailSetting = n.GetStringValue(); } },
                {"title", n => { Title = n.GetStringValue(); } },
                {"users", n => { Users = n.GetCollectionOfObjectValues<User>(User.CreateFromDiscriminatorValue)?.ToList(); } },
                {"usersNavigationLink", n => { UsersNavigationLink = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("allowMembersEditMembership", AllowMembersEditMembership);
            writer.WriteBoolValue("allowRequestToJoinLeave", AllowRequestToJoinLeave);
            writer.WriteBoolValue("autoAcceptRequestToJoinLeave", AutoAcceptRequestToJoinLeave);
            writer.WriteStringValue("description", Description);
            writer.WriteIntValue("id", Id);
            writer.WriteBoolValue("isHiddenInUI", IsHiddenInUI);
            writer.WriteStringValue("loginName", LoginName);
            writer.WriteBoolValue("onlyAllowMembersViewMembership", OnlyAllowMembersViewMembership);
            writer.WriteObjectValue<Principal>("owner", Owner);
            writer.WriteStringValue("ownerNavigationLink", OwnerNavigationLink);
            writer.WriteStringValue("ownerTitle", OwnerTitle);
            writer.WriteIntValue("principalType", PrincipalType);
            writer.WriteStringValue("requestToJoinLeaveEmailSetting", RequestToJoinLeaveEmailSetting);
            writer.WriteStringValue("title", Title);
            writer.WriteStringValue("usersNavigationLink", UsersNavigationLink);
        }
    }
}