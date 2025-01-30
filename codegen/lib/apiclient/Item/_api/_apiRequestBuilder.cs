// <auto-generated/>
#pragma warning disable CS0618
using Graph.Community.Item._api.HubSites;
using Graph.Community.Item._api.Site;
using Graph.Community.Item._api.SitePages;
using Graph.Community.Item._api.Web;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace Graph.Community.Item._api
{
    /// <summary>
    /// Builds and executes requests for operations under \{serverRelativeSiteUrl}\_api
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class _apiRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The HubSites property</summary>
        public global::Graph.Community.Item._api.HubSites.HubSitesRequestBuilder HubSites
        {
            get => new global::Graph.Community.Item._api.HubSites.HubSitesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The site property</summary>
        public global::Graph.Community.Item._api.Site.SiteRequestBuilder Site
        {
            get => new global::Graph.Community.Item._api.Site.SiteRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The SitePages property</summary>
        public global::Graph.Community.Item._api.SitePages.SitePagesRequestBuilder SitePages
        {
            get => new global::Graph.Community.Item._api.SitePages.SitePagesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The web property</summary>
        public global::Graph.Community.Item._api.Web.WebRequestBuilder Web
        {
            get => new global::Graph.Community.Item._api.Web.WebRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Graph.Community.Item._api._apiRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public _apiRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/{serverRelativeSiteUrl}/_api", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Graph.Community.Item._api._apiRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public _apiRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/{serverRelativeSiteUrl}/_api", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
