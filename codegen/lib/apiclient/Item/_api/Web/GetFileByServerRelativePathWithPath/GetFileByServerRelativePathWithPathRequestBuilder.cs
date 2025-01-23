// <auto-generated/>
#pragma warning disable CS0618
using Graph.Community.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath
{
    /// <summary>
    /// Builds and executes requests for operations under \{serverRelativeSiteUrl}\_api\web\GetFileByServerRelativePath(DecodedUrl=@path)
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class GetFileByServerRelativePathWithPathRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath.GetFileByServerRelativePathWithPathRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GetFileByServerRelativePathWithPathRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/{serverRelativeSiteUrl}/_api/web/GetFileByServerRelativePath(DecodedUrl=@path)?@path={%40path}{&%24expand,%24select}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath.GetFileByServerRelativePathWithPathRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GetFileByServerRelativePathWithPathRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/{serverRelativeSiteUrl}/_api/web/GetFileByServerRelativePath(DecodedUrl=@path)?@path={%40path}{&%24expand,%24select}", rawUrl)
        {
        }
        /// <returns>A <see cref="global::Graph.Community.Models.FileObject"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Graph.Community.Models.FileObject?> GetAsync(Action<RequestConfiguration<global::Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath.GetFileByServerRelativePathWithPathRequestBuilder.GetFileByServerRelativePathWithPathRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Graph.Community.Models.FileObject> GetAsync(Action<RequestConfiguration<global::Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath.GetFileByServerRelativePathWithPathRequestBuilder.GetFileByServerRelativePathWithPathRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<global::Graph.Community.Models.FileObject>(requestInfo, global::Graph.Community.Models.FileObject.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath.GetFileByServerRelativePathWithPathRequestBuilder.GetFileByServerRelativePathWithPathRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath.GetFileByServerRelativePathWithPathRequestBuilder.GetFileByServerRelativePathWithPathRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath.GetFileByServerRelativePathWithPathRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath.GetFileByServerRelativePathWithPathRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Graph.Community.Item._api.Web.GetFileByServerRelativePathWithPath.GetFileByServerRelativePathWithPathRequestBuilder(rawUrl, RequestAdapter);
        }
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        #pragma warning disable CS1591
        public partial class GetFileByServerRelativePathWithPathRequestBuilderGetQueryParameters 
        #pragma warning restore CS1591
        {
            /// <summary>OData system query option $expand.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24expand")]
            public string[]? Expand { get; set; }
#nullable restore
#else
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
#endif
            /// <summary>Decoded server relative path of the file.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%40path")]
            public string? Path { get; set; }
#nullable restore
#else
            [QueryParameter("%40path")]
            public string Path { get; set; }
#endif
            /// <summary>OData system query option $select.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24select")]
            public string[]? Select { get; set; }
#nullable restore
#else
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
#endif
        }
    }
}
#pragma warning restore CS0618
