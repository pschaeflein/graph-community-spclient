// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Kiota.SharePoint.Client.Models {
    public class SiteDesignMetadata : IParsable 
    {
        /// <summary>The designPackageId property</summary>
        public Guid? DesignPackageId { get; set; }
        /// <summary>The designType property</summary>
        public int? DesignType { get; set; }
        /// <summary>The isDefault property</summary>
        public bool? IsDefault { get; set; }
        /// <summary>The isOutOfBoxTemplate property</summary>
        public bool? IsOutOfBoxTemplate { get; set; }
        /// <summary>The isTenantAdminOnly property</summary>
        public bool? IsTenantAdminOnly { get; set; }
        /// <summary>The listColor property</summary>
        public int? ListColor { get; set; }
        /// <summary>The listIcon property</summary>
        public int? ListIcon { get; set; }
        /// <summary>The order property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Order { get; set; }
#nullable restore
#else
        public string Order { get; set; }
#endif
        /// <summary>The previewImageAltText property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PreviewImageAltText { get; set; }
#nullable restore
#else
        public string PreviewImageAltText { get; set; }
#endif
        /// <summary>The previewImageUrl property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PreviewImageUrl { get; set; }
#nullable restore
#else
        public string PreviewImageUrl { get; set; }
#endif
        /// <summary>The requiresGroupConnected property</summary>
        public bool? RequiresGroupConnected { get; set; }
        /// <summary>The requiresTeamsConnected property</summary>
        public bool? RequiresTeamsConnected { get; set; }
        /// <summary>The requiresYammerConnected property</summary>
        public bool? RequiresYammerConnected { get; set; }
        /// <summary>The siteScriptIds property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Guid?>? SiteScriptIds { get; set; }
#nullable restore
#else
        public List<Guid?> SiteScriptIds { get; set; }
#endif
        /// <summary>The supportedWebTemplates property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? SupportedWebTemplates { get; set; }
#nullable restore
#else
        public List<string> SupportedWebTemplates { get; set; }
#endif
        /// <summary>The templateFeatures property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? TemplateFeatures { get; set; }
#nullable restore
#else
        public List<string> TemplateFeatures { get; set; }
#endif
        /// <summary>The thumbnailUrl property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ThumbnailUrl { get; set; }
#nullable restore
#else
        public string ThumbnailUrl { get; set; }
#endif
        /// <summary>The title property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Title { get; set; }
#nullable restore
#else
        public string Title { get; set; }
#endif
        /// <summary>The version property</summary>
        public int? Version { get; set; }
        /// <summary>The webTemplate property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? WebTemplate { get; set; }
#nullable restore
#else
        public string WebTemplate { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="SiteDesignMetadata"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static SiteDesignMetadata CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SiteDesignMetadata();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"designPackageId", n => { DesignPackageId = n.GetGuidValue(); } },
                {"designType", n => { DesignType = n.GetIntValue(); } },
                {"isDefault", n => { IsDefault = n.GetBoolValue(); } },
                {"isOutOfBoxTemplate", n => { IsOutOfBoxTemplate = n.GetBoolValue(); } },
                {"isTenantAdminOnly", n => { IsTenantAdminOnly = n.GetBoolValue(); } },
                {"listColor", n => { ListColor = n.GetIntValue(); } },
                {"listIcon", n => { ListIcon = n.GetIntValue(); } },
                {"order", n => { Order = n.GetStringValue(); } },
                {"previewImageAltText", n => { PreviewImageAltText = n.GetStringValue(); } },
                {"previewImageUrl", n => { PreviewImageUrl = n.GetStringValue(); } },
                {"requiresGroupConnected", n => { RequiresGroupConnected = n.GetBoolValue(); } },
                {"requiresTeamsConnected", n => { RequiresTeamsConnected = n.GetBoolValue(); } },
                {"requiresYammerConnected", n => { RequiresYammerConnected = n.GetBoolValue(); } },
                {"siteScriptIds", n => { SiteScriptIds = n.GetCollectionOfPrimitiveValues<Guid?>()?.ToList(); } },
                {"supportedWebTemplates", n => { SupportedWebTemplates = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"templateFeatures", n => { TemplateFeatures = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"thumbnailUrl", n => { ThumbnailUrl = n.GetStringValue(); } },
                {"title", n => { Title = n.GetStringValue(); } },
                {"version", n => { Version = n.GetIntValue(); } },
                {"webTemplate", n => { WebTemplate = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteGuidValue("designPackageId", DesignPackageId);
            writer.WriteIntValue("designType", DesignType);
            writer.WriteBoolValue("isDefault", IsDefault);
            writer.WriteBoolValue("isOutOfBoxTemplate", IsOutOfBoxTemplate);
            writer.WriteBoolValue("isTenantAdminOnly", IsTenantAdminOnly);
            writer.WriteIntValue("listColor", ListColor);
            writer.WriteIntValue("listIcon", ListIcon);
            writer.WriteStringValue("order", Order);
            writer.WriteStringValue("previewImageAltText", PreviewImageAltText);
            writer.WriteStringValue("previewImageUrl", PreviewImageUrl);
            writer.WriteBoolValue("requiresGroupConnected", RequiresGroupConnected);
            writer.WriteBoolValue("requiresTeamsConnected", RequiresTeamsConnected);
            writer.WriteBoolValue("requiresYammerConnected", RequiresYammerConnected);
            writer.WriteCollectionOfPrimitiveValues<Guid?>("siteScriptIds", SiteScriptIds);
            writer.WriteCollectionOfPrimitiveValues<string>("supportedWebTemplates", SupportedWebTemplates);
            writer.WriteCollectionOfPrimitiveValues<string>("templateFeatures", TemplateFeatures);
            writer.WriteStringValue("thumbnailUrl", ThumbnailUrl);
            writer.WriteStringValue("title", Title);
            writer.WriteIntValue("version", Version);
            writer.WriteStringValue("webTemplate", WebTemplate);
        }
    }
}
