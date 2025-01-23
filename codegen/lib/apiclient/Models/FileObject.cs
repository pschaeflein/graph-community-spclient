// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Graph.Community.Models
{
    /// <summary>
    /// Basic information about a file.(To get complete information, use the Microsoft Graph endpoint.)
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class FileObject : IAdditionalDataHolder, IParsable
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The CheckedOutByUser property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Graph.Community.Models.User? CheckedOutByUser { get; set; }
#nullable restore
#else
        public global::Graph.Community.Models.User CheckedOutByUser { get; set; }
#endif
        /// <summary>The CheckInComment property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CheckInComment { get; set; }
#nullable restore
#else
        public string CheckInComment { get; set; }
#endif
        /// <summary>A value that indicates how the file is checked out of a document library. Represents an SP.CheckOutType value: Online = 0; Offline = 1; None = 2.</summary>
        public int? CheckOutType { get; set; }
        /// <summary>A value that specifies the customization status of the file. Represents an SP.CustomizedPageStatus value: None = 0; Uncustomized = 1; Customized = 2</summary>
        public int? CustomizedPageStatus { get; set; }
        /// <summary>The Exists property</summary>
        public bool? Exists { get; set; }
        /// <summary>A value that specifies the publishing level of the file. Represents an SP.FileLevel value: Published = 1; Draft = 2; Checkout = 255.</summary>
        public int? Level { get; set; }
        /// <summary>The LockedByUser property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Graph.Community.Models.User? LockedByUser { get; set; }
#nullable restore
#else
        public global::Graph.Community.Models.User LockedByUser { get; set; }
#endif
        /// <summary>The MajorVersion property</summary>
        public int? MajorVersion { get; set; }
        /// <summary>The MinorVersion property</summary>
        public int? MinorVersion { get; set; }
        /// <summary>The Name property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>The ServerRelativeUrl property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ServerRelativeUrl { get; set; }
#nullable restore
#else
        public string ServerRelativeUrl { get; set; }
#endif
        /// <summary>The TimeCreated property</summary>
        public DateTimeOffset? TimeCreated { get; set; }
        /// <summary>The TimeLastModified property</summary>
        public DateTimeOffset? TimeLastModified { get; set; }
        /// <summary>The Title property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Title { get; set; }
#nullable restore
#else
        public string Title { get; set; }
#endif
        /// <summary>The UIVersionLabel property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? UIVersionLabel { get; set; }
#nullable restore
#else
        public string UIVersionLabel { get; set; }
#endif
        /// <summary>The UniqueId property</summary>
        public Guid? UniqueId { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::Graph.Community.Models.FileObject"/> and sets the default values.
        /// </summary>
        public FileObject()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Graph.Community.Models.FileObject"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::Graph.Community.Models.FileObject CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::Graph.Community.Models.FileObject();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "CheckInComment", n => { CheckInComment = n.GetStringValue(); } },
                { "CheckOutType", n => { CheckOutType = n.GetIntValue(); } },
                { "CheckedOutByUser", n => { CheckedOutByUser = n.GetObjectValue<global::Graph.Community.Models.User>(global::Graph.Community.Models.User.CreateFromDiscriminatorValue); } },
                { "CustomizedPageStatus", n => { CustomizedPageStatus = n.GetIntValue(); } },
                { "Exists", n => { Exists = n.GetBoolValue(); } },
                { "Level", n => { Level = n.GetIntValue(); } },
                { "LockedByUser", n => { LockedByUser = n.GetObjectValue<global::Graph.Community.Models.User>(global::Graph.Community.Models.User.CreateFromDiscriminatorValue); } },
                { "MajorVersion", n => { MajorVersion = n.GetIntValue(); } },
                { "MinorVersion", n => { MinorVersion = n.GetIntValue(); } },
                { "Name", n => { Name = n.GetStringValue(); } },
                { "ServerRelativeUrl", n => { ServerRelativeUrl = n.GetStringValue(); } },
                { "TimeCreated", n => { TimeCreated = n.GetDateTimeOffsetValue(); } },
                { "TimeLastModified", n => { TimeLastModified = n.GetDateTimeOffsetValue(); } },
                { "Title", n => { Title = n.GetStringValue(); } },
                { "UIVersionLabel", n => { UIVersionLabel = n.GetStringValue(); } },
                { "UniqueId", n => { UniqueId = n.GetGuidValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::Graph.Community.Models.User>("CheckedOutByUser", CheckedOutByUser);
            writer.WriteStringValue("CheckInComment", CheckInComment);
            writer.WriteIntValue("CheckOutType", CheckOutType);
            writer.WriteIntValue("CustomizedPageStatus", CustomizedPageStatus);
            writer.WriteBoolValue("Exists", Exists);
            writer.WriteIntValue("Level", Level);
            writer.WriteObjectValue<global::Graph.Community.Models.User>("LockedByUser", LockedByUser);
            writer.WriteIntValue("MajorVersion", MajorVersion);
            writer.WriteIntValue("MinorVersion", MinorVersion);
            writer.WriteStringValue("Name", Name);
            writer.WriteStringValue("ServerRelativeUrl", ServerRelativeUrl);
            writer.WriteDateTimeOffsetValue("TimeCreated", TimeCreated);
            writer.WriteDateTimeOffsetValue("TimeLastModified", TimeLastModified);
            writer.WriteStringValue("Title", Title);
            writer.WriteStringValue("UIVersionLabel", UIVersionLabel);
            writer.WriteGuidValue("UniqueId", UniqueId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
