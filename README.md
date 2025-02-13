# Graph Community SharePoint Client 

The Graph.Community.SPClient library is a community effort to unblock developers building on .Net Standard who need to call endpoints that are not part of the Microsoft Graph.

[![Build](https://github.com/pschaeflein/graph-community-spclient/actions/workflows/build.yml/badge.svg?branch=main&event=push)](https://github.com/pschaeflein/graph-community-spclient/actions/workflows/build.yml)
[![NuGet package](https://img.shields.io/nuget/v/Graph.Community.SPClient)](https://www.nuget.org/packages/Graph.Community.SPClient/)

## Highlights

This community library is a Kiota-generate client for a subset of the SharePoint REST API (_api).

The client library allows for using the same coding practices and capabilities of the Microsoft Graph SDK. Key benefits of that library:

- Leverage SDK-provided functionality such as authorization, compression and retries.
- Provide a consistent coding style to the Microsoft cloud, regardless of the endpoint (Graph, SharePoint REST, etc.)

### SharePoint REST API context

The SharePoint REST API must be called in the context of a site. As noted in the official documentation, [The main entry points for the REST service represent the site collection and site of the specified context.](https://learn.microsoft.com/en-us/sharepoint/dev/sp-add-ins/get-to-know-the-sharepoint-rest-service?tabs=csom#construct-rest-urls-to-access-sharepoint-resources):

- `https://{site_url}/_api/site`
- `https://{site_url}/_api/web`

The `{site_url}` in this context contains the tenant hostname (`https://{tenant}.sharepoint.com`) and the site path (/`sites/{site_name}`). When using the Graph.Community.SPClient:
- The hostname must be provided to the factory method. (This sets the base url for all requests invoked via the client.)
- The site path must be specified when building the request. The site path is an "indexer" into the sites collection. (While this is not technically correct, it matches the style of collections throughout Kiota-generated clients.)

Putting this together, a typical request to the SharePoint REST API looks like this:

```csharp
var client = SPClientFactory.CreateClient("https://contoso.sharepoint.com", new TokenCredential(token));
var web = await spClient["/sites/somesite"]._api.Web.GetAsync();
```

### SharePoint REST endpoints

View the [Graph.Community OpenAPI description](https://pschaeflein.github.io/graph-community-metadata/) to see the specific endpoints included.

Some of the endpoints are adjusted to make them similar to typical REST (or Graph) style. Specific updates:

| Endpoint | Description |
-|-
| Site Designs/Site Scripts | The namespace in this library is shorted to simply 'SiteScriptUtility'. Refer to the SiteDesign.cs file in the sample project.
| Lists | The SharePoint REST API uses a method syntax for Lists (e.g. `_api/web/lists/getById` or `_api/web/lists/guid('{list_guid'})`). In the SPClient, the list_guid is an indexer into the lists collection (e.g. `_api.Web.Lists[{list_guid}}]``)
| SitePages | The namespace in this library is shorted to simply 'SitePage'. Refer to the SitePage.cs file in the sample project.

If there is an endpoint node for which you would like a request, please submit an issue to initiate a conversation. This will help reduce wasted effort.

### SharePoint models/objects

The top-level classes that are generated use the name assigned by the API metadata. This means the Graph.Community namespace contains classes named SPWeb, SPList, etc. These are not identical the classes found in the offical SharePoint CSOM SDK. This is intentional.

The Graph.Community.SPClient library is not intended to replace the CSOM libraries, nor the Graph SDK. The class contain only the properties that are not available thru Microsoft Graph. (But, all of the Kiota-generated classes contain a dictionary named AdditionalProperties. So what you are looking for may be in there. ;) )

### SharePoint service handler
The SharePoint REST endpoint requires a specific request header, and the error messages follow a proprietary format. The SPClient includes a delegating handler that inserts the header, and reformats service exceptions to an in stance of the ODataError class. This handler is automatically added to the Http pipeline when using the client factory class.

## Getting Started

The samples folder includes a console application that demonstrates most of the client capabilities. The sample calls follow a standard pattern:

- Create a TokenCredential for authenticating to SharePoint
- Configure the client to log the request/response information (helpful for troubleshooting)
- Invoke the endpoint

### Configuring the client via the SPClientOptions class

The SPClientOptions class provides for setting the [UserAgent string as required for SharePoint](https://learn.microsoft.com/en-us/sharepoint/dev/general-development/how-to-avoid-getting-throttled-or-blocked-in-sharepoint-online).

### Using the client factory

The client factory requires the SharePoint hostname of the tenant. (This differs from Microsoft Graph, which uses a single hostname for all tenants.)

The factory also requires a TokenCredential instance or custom Authentication provider. SharePoint Online will accept a token from Entra Id if the scopes include the SharePoint tenant (https://[tenant].sharepoint.com/[scope]).
