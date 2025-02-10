# Graph Community SharePoint Client 

The Graph.Community.SPClient library is a community effort to unblock developers building on .Net Standard who need to call endpoints that are not part of the Microsoft Graph.

[![Build](https://github.com/pschaeflein/graph-community-spclient/actions/workflows/build.yml/badge.svg?branch=main&event=push)](https://github.com/pschaeflein/graph-community-spclient/actions/workflows/build.yml)
[![NuGet package](https://img.shields.io/nuget/v/Graph.Community.SPClient)](https://www.nuget.org/packages/Graph.Community.SPClient/)

## Highlights

This community library is a Kiota-generate client for a subset of the SharePoint REST API (_api).

The client library allows for using the same coding practices and capabilities of the Microsoft Graph SDK. Key benefits of that library:

- Leverage SDK-provided functionality such as authorization, compression and retries.
- Provide a consistent coding style to the Microsoft cloud, regardless of the endpoint (Graph, SharePoint REST, etc.)

### SharePoint REST endpoints
View the [Graph.Community OpenAPI description](https://pschaeflein.github.io/graph-community-metadata/) to see the specific endpoints included.

If there is an endpoint node for which you would like a request, please submit an issue to initiate a conversation. This will help reduce wasted effort.

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

The factory also requires a TokenCredential instance or custom Authentication provider. SharePoint Online will accept a token from Entra Id if the scopes include the SharePoint tenant (https://<tenant>.sharepoint.com/<scope>).
