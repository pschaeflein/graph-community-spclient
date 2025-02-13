// <auto-generated/>
#pragma warning disable CS0618
using Graph.Community.Item._api.Web.Lists.GetByTitleWithTitle;
using Graph.Community.Item._api.Web.Lists.Item;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Graph.Community.Item._api.Web.Lists
{
    /// <summary>
    /// Builds and executes requests for operations under \{serverRelativeSiteUrl}\_api\web\lists
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class ListsRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the Graph.Community.item._api.web.lists.item collection</summary>
        /// <param name="position">The Id of the list.</param>
        /// <returns>A <see cref="global::Graph.Community.Item._api.Web.Lists.Item.ListsItemRequestBuilder"/></returns>
        public global::Graph.Community.Item._api.Web.Lists.Item.ListsItemRequestBuilder this[Guid position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("id", position);
                return new global::Graph.Community.Item._api.Web.Lists.Item.ListsItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Graph.Community.Item._api.Web.Lists.ListsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ListsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/{serverRelativeSiteUrl}/_api/web/lists{?%24select}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Graph.Community.Item._api.Web.Lists.ListsRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ListsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/{serverRelativeSiteUrl}/_api/web/lists{?%24select}", rawUrl)
        {
        }
        /// <summary>
        /// Returns basic information about all lists in the site. (To get complete information, use the Microsoft Graph endpoint.)
        /// </summary>
        /// <returns>A <see cref="global::Graph.Community.Item._api.Web.Lists.ListsGetResponse"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Graph.Community.Item._api.Web.Lists.ListsGetResponse?> GetAsync(Action<RequestConfiguration<global::Graph.Community.Item._api.Web.Lists.ListsRequestBuilder.ListsRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Graph.Community.Item._api.Web.Lists.ListsGetResponse> GetAsync(Action<RequestConfiguration<global::Graph.Community.Item._api.Web.Lists.ListsRequestBuilder.ListsRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<global::Graph.Community.Item._api.Web.Lists.ListsGetResponse>(requestInfo, global::Graph.Community.Item._api.Web.Lists.ListsGetResponse.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Builds and executes requests for operations under \{serverRelativeSiteUrl}\_api\web\lists\GetByTitle(&apos;{title}&apos;)
        /// </summary>
        /// <returns>A <see cref="global::Graph.Community.Item._api.Web.Lists.GetByTitleWithTitle.GetByTitleWithTitleRequestBuilder"/></returns>
        /// <param name="title">The Title of the list.</param>
        public global::Graph.Community.Item._api.Web.Lists.GetByTitleWithTitle.GetByTitleWithTitleRequestBuilder GetByTitle(string title)
        {
            if(string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));
            return new global::Graph.Community.Item._api.Web.Lists.GetByTitleWithTitle.GetByTitleWithTitleRequestBuilder(PathParameters, RequestAdapter, title);
        }
        /// <summary>
        /// Returns basic information about all lists in the site. (To get complete information, use the Microsoft Graph endpoint.)
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Graph.Community.Item._api.Web.Lists.ListsRequestBuilder.ListsRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Graph.Community.Item._api.Web.Lists.ListsRequestBuilder.ListsRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::Graph.Community.Item._api.Web.Lists.ListsRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Graph.Community.Item._api.Web.Lists.ListsRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Graph.Community.Item._api.Web.Lists.ListsRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Returns basic information about all lists in the site. (To get complete information, use the Microsoft Graph endpoint.)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class ListsRequestBuilderGetQueryParameters 
        {
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
