// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Graph.Community.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class SPUser : global::Graph.Community.Models.SPPrincipal, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The e-mail address of the user.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Email { get; set; }
#nullable restore
#else
        public string Email { get; set; }
#endif
        /// <summary>IsEmailAuthenticationGuestUser</summary>
        public bool? IsEmailAuthenticationGuestUser { get; set; }
        /// <summary>IsShareByEmailGuestUser</summary>
        public bool? IsShareByEmailGuestUser { get; set; }
        /// <summary>Whether the user is a site collection administrator.</summary>
        public bool? IsSiteAdmin { get; set; }
        /// <summary>The user&apos;s name identifier and the issuer of the user&apos;s name identifier.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Graph.Community.Models.UserId? UserId { get; set; }
#nullable restore
#else
        public global::Graph.Community.Models.UserId UserId { get; set; }
#endif
        /// <summary>UserPrincipalName</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? UserPrincipalName { get; set; }
#nullable restore
#else
        public string UserPrincipalName { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Graph.Community.Models.SPUser"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::Graph.Community.Models.SPUser CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::Graph.Community.Models.SPUser();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "Email", n => { Email = n.GetStringValue(); } },
                { "IsEmailAuthenticationGuestUser", n => { IsEmailAuthenticationGuestUser = n.GetBoolValue(); } },
                { "IsShareByEmailGuestUser", n => { IsShareByEmailGuestUser = n.GetBoolValue(); } },
                { "IsSiteAdmin", n => { IsSiteAdmin = n.GetBoolValue(); } },
                { "UserId", n => { UserId = n.GetObjectValue<global::Graph.Community.Models.UserId>(global::Graph.Community.Models.UserId.CreateFromDiscriminatorValue); } },
                { "UserPrincipalName", n => { UserPrincipalName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("Email", Email);
            writer.WriteBoolValue("IsEmailAuthenticationGuestUser", IsEmailAuthenticationGuestUser);
            writer.WriteBoolValue("IsShareByEmailGuestUser", IsShareByEmailGuestUser);
            writer.WriteBoolValue("IsSiteAdmin", IsSiteAdmin);
            writer.WriteObjectValue<global::Graph.Community.Models.UserId>("UserId", UserId);
            writer.WriteStringValue("UserPrincipalName", UserPrincipalName);
        }
    }
}
#pragma warning restore CS0618
