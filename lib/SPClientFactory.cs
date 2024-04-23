using Azure.Core;
using Graph.Community.Middleware;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Authentication.Azure;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Microsoft.Kiota.Http.HttpClientLibrary.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Graph.Community
{
  /// <summary>
  /// KiotaSharePointClientFactory class to create the HTTP client configured to support Community-created requests 
  /// </summary>
  public static class SPClientFactory
  {
    internal static bool TelemetryDisabled { get; set; }

    private static SharePointThrottlingDecoration defaultDecoration = new()
    {
      CompanyName = "GraphCommunity",
      AppName = "SPClient",
      AppVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(SPClientFactory).Assembly.Location).FileVersion
    };

    /*  
     *  Summary of factory methods:
     *  - TokenCredential or AuthenticationProvider
     *  - With or without list of middleware handlers to register
    */

    public static SPClient Create(string spoTenantUrl, TokenCredential tokenCredential, SPClientOptions? options = null, IEnumerable<string>? scopes = null)
    {
      var authProvider = new BaseBearerTokenAuthenticationProvider(new AzureIdentityAccessTokenProvider(tokenCredential, null, null, scopes?.ToArray() ?? Array.Empty<string>()));
      return Create(spoTenantUrl, authProvider, options);
    }

    public static SPClient Create(string spoTenantUrl, TokenCredential tokenCredential, List<DelegatingHandler> handlers, SPClientOptions? options = null, IEnumerable<string>? scopes = null)
    {
      var authProvider = new BaseBearerTokenAuthenticationProvider(new AzureIdentityAccessTokenProvider(tokenCredential, null, null, scopes?.ToArray() ?? Array.Empty<string>()));
      return Create(spoTenantUrl, authProvider, handlers, options);
    }

    public static SPClient Create(string spoTenantUrl, IAuthenticationProvider authenticationProvider, SPClientOptions? options = null)
    {
      if (string.IsNullOrEmpty(spoTenantUrl))
      {
        throw new ArgumentException($"'{nameof(spoTenantUrl)}' cannot be null or empty.", nameof(spoTenantUrl));
      }

      options ??= new();

      var userAgentHandlerOption = (options.UserAgentInfo.HasValue && !options.UserAgentInfo.Value.IsEmpty())
          ? options.UserAgentInfo.Value.ToUserAgentHandlerOption()
          : defaultDecoration.ToUserAgentHandlerOption();

      var handlers = new List<DelegatingHandler>
      {
        new SharePointServiceHandler(),
        new RetryHandler(),
        new RedirectHandler(),
        new ParametersNameDecodingHandler(),
        new UserAgentHandler(userAgentHandlerOption),
        new HeadersInspectionHandler(),
      };

      return Create(spoTenantUrl, authenticationProvider, handlers, options);
    }

    public  static SPClient Create(string spoTenantUrl, IAuthenticationProvider authenticationProvider, List<DelegatingHandler> handlers, SPClientOptions? options = null)
    {
      if (string.IsNullOrWhiteSpace(spoTenantUrl))
      {
        throw new ArgumentException($"'{nameof(spoTenantUrl)}' cannot be null or whitespace.", nameof(spoTenantUrl));
      }

      if (authenticationProvider is null)
      {
        throw new ArgumentNullException(nameof(authenticationProvider));
      }

      if (handlers is null)
      {
        throw new ArgumentNullException(nameof(handlers));
      }

      // add our handler if not included...
      bool spHandlerIncluded = false;
      foreach (var handler in handlers)
      {
        if (handler is SharePointServiceHandler)
        {
          spHandlerIncluded=true;
          break;
        }
      }

      if (!spHandlerIncluded)
      {
        handlers.Insert(0, new SharePointServiceHandler());
      }

      // if configured, add the logger to the handlers
      if (options?.MessageLogger != null)
      {
        handlers.Insert(0, new LoggingMessageHandler(options.MessageLogger));
      }

      var httpMessageHandler = KiotaClientFactory.ChainHandlersCollectionAndGetFirstLink(
        KiotaClientFactory.GetDefaultHttpMessageHandler(),
        handlers.ToArray()
      );

      var httpClient = new HttpClient(httpMessageHandler!);

      var adapter = new HttpClientRequestAdapter(authenticationProvider, httpClient: httpClient);
      adapter.BaseUrl = spoTenantUrl;

      var client = new SPClient(adapter);

      return client;
    }
  }
}
