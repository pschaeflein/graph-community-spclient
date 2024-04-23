using Azure.Identity;
using Microsoft.Extensions.Options;

namespace Graph.Community.SPClient.Sample
{
  public class Diagnostics
  {
    private readonly AzureAdSettings azureAdSettings;
    private readonly SharePointSettings sharePointSettings;

    public Diagnostics(
      IOptions<AzureAdSettings> azureAdOptions,
      IOptions<SharePointSettings> sharePointOptions)
    {
      this.azureAdSettings = azureAdOptions.Value;
      this.sharePointSettings = sharePointOptions.Value;
    }


    public async Task Run()
    {
      ////////////////////////////////////////
      //
      // Capture all diagnostic information
      //
      ///////////////////////////////////////

      // Start with an IHttpMessageLogger that will write to a StringBuilder 
      var logger = new StringBuilderHttpMessageLogger();
      /*
       *  Could also use the Console if preferred...
       *  
       *  var logger = new ConsoleHttpMessageLogger();
       */


      // MSAL provides logging via a callback on the client application.
      //  Write those entries to the same logger, prefixed with MSAL
      //async void MSALLogging(LogLevel level, string message, bool containsPii)
      //{
      //	await logger.WriteLine($"MSAL {level} {containsPii} {message}");
      //}


      //////////////////////
      //
      //  TokenCredential 
      //
      //////////////////////

      var credential = new ChainedTokenCredential(
        new SharedTokenCacheCredential(new SharedTokenCacheCredentialOptions() { TenantId = azureAdSettings.TenantId, ClientId = azureAdSettings.ClientId }),
        //new VisualStudioCredential(new VisualStudioCredentialOptions { TenantId = azureAdSettings.TenantId }),
        new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TenantId = azureAdSettings.TenantId, ClientId = azureAdSettings.ClientId })
      );


      ////////////////////////////////////////////////////////////
      //
      // Graph Client with Logger and SharePoint service handler
      //
      ////////////////////////////////////////////////////////////

      // Configure our client
      SPClientOptions clientOptions = new ()
      {
        // use our logger
        MessageLogger = logger

        // use the default user agent
      };

      var ksClient = SPClientFactory.Create(sharePointSettings.SpoTenantUrl, credential, clientOptions);

      ///////////////////////////////////////
      //
      // Setup is complete, run the sample
      //
      ///////////////////////////////////////

      try
      {
        var web = await ksClient[sharePointSettings.ServerRelativeSiteUrl]._api.Web.GetAsync();

        Console.WriteLine($"Title: {web.Title}");
      }
      catch (Exception ex)
      {
        await logger.WriteLine("");
        await logger.WriteLine("================== Exception caught ==================");
        await logger.WriteLine(ex.ToString());
      }


      Console.WriteLine("Press enter to show log");
      Console.ReadLine();
      Console.WriteLine();
      var log = logger.GetLog();
      Console.WriteLine(log);
    }
  }

}

