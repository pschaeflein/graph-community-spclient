using Azure.Core;
using Kiota.SharePoint.Client;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Authentication.Azure;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Microsoft.Kiota.Http.HttpClientLibrary.Middleware;
using Microsoft.Kiota.Http.HttpClientLibrary.Middleware.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Kiota.SharePoint
{
  /// <summary>
  /// KiotaSharePointClientFactory class to create the HTTP client configured to support Community-created requests 
  /// </summary>
  public static class KiotaSharePointClientFactory
  {
    internal static bool TelemetryDisabled { get; set; }

    private static SharePointThrottlingDecoration defaultDecoration = new()
    {
      CompanyName = "GraphCommunity",
      AppName = "KiotaSharePointClient",
      AppVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(KiotaSharePointClientFactory).Assembly.Location).FileVersion
    };

    /*  
     *  Consider overload that accepts the various handler options
     *  
    */

    public static KiotaSharePointClient Create(KiotaSharePointClientOptions options, TokenCredential tokenCredential, IEnumerable<string>? scopes = null, string? baseUrl = null)
    {
      var authProvider = new BaseBearerTokenAuthenticationProvider(new AzureIdentityAccessTokenProvider(tokenCredential, null, null, scopes?.ToArray() ?? Array.Empty<string>()));
      return Create(options,authProvider, baseUrl);
    }

    public static KiotaSharePointClient Create(KiotaSharePointClientOptions options, IAuthenticationProvider authenticationProvider, string? baseUrl = null)
    {
      if (options == null)
      {
        throw new ArgumentNullException("options");
      }

      var userAgentHandlerOption = defaultDecoration.ToUserAgentHandlerOption();
      
      if (options.UserAgentInfo.HasValue && 
          !options.UserAgentInfo.Value.IsEmpty())
      {
        userAgentHandlerOption = options.UserAgentInfo.Value.ToUserAgentHandlerOption();
      }

      var handlers = CreateDefaultHandlers(userAgentHandlerOption);

      handlers.Add(new SharePointServiceHandler());

      if (options.MessageLogger!=null)
      {
        handlers.Add(new LoggingMessageHandler(options.MessageLogger));
      }

      var httpMessageHandler = KiotaClientFactory.ChainHandlersCollectionAndGetFirstLink(
        KiotaClientFactory.GetDefaultHttpMessageHandler(),
        handlers.ToArray()
      );

      var httpClient = new HttpClient(httpMessageHandler!);

      var adapter = new HttpClientRequestAdapter(authenticationProvider, httpClient: httpClient);
      adapter.BaseUrl = baseUrl;

      var client = new KiotaSharePointClient(adapter); 

      return client;  
    }


    /// <summary>
    /// Creates a default set of middleware to be used by the <see cref="HttpClient"/>.
    /// </summary>
    /// <remarks>Copied from Microsoft.Kiota.Http.HttpClientLibrary.KiotaClientFactory because I want to set UserAgentHandler Options once instead of on every request.</remarks>
    /// <returns>A list of the default handlers used by the client.</returns>
    private static IList<DelegatingHandler> CreateDefaultHandlers(UserAgentHandlerOption? userAgentHandlerOption = null)
    {
      return new List<DelegatingHandler>
      {
        //add the default middlewares as they are ready
        new RetryHandler(),
        new RedirectHandler(),
        new ParametersNameDecodingHandler(),
        new UserAgentHandler(userAgentHandlerOption),
        new HeadersInspectionHandler(),
      };
    }
  }
}
