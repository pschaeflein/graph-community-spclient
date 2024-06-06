using Azure.Identity;
using Microsoft.Extensions.Options;


namespace Graph.Community.SPClient.Sample
{
  internal class HubSiteList
  {
    private readonly AzureAdSettings azureAdSettings;
    private readonly SharePointSettings sharePointSettings;

    public HubSiteList(
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
      // Capture diagnostic information
      //
      ///////////////////////////////////////

      var logger = new StringBuilderHttpMessageLogger();

      //////////////////////
      //
      //  TokenCredential 
      //
      //////////////////////

      var credential = new ChainedTokenCredential(
        new SharedTokenCacheCredential(new SharedTokenCacheCredentialOptions() { TenantId = azureAdSettings.TenantId, ClientId = azureAdSettings.ClientId }),
        new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions { TenantId = azureAdSettings.TenantId, ClientId = azureAdSettings.ClientId })
      );


      ////////////////////////////////////////////////////////////
      //
      // SharePoint REST Client with Logger and SharePoint service handler
      //
      ////////////////////////////////////////////////////////////

      // Configure our client
      SPClientOptions clientOptions = new()
      {
        // use the default user agent

        //UserAgentInfo = new SharePointThrottlingDecoration()
        //{
        //  CompanyName = "Company",
        //  AppName = "Application",
        //  AppVersion = "0.0.0",
        //  ISV = false
        //},

        // use our logger
        MessageLogger = logger
      };

      var spClient = SPClientFactory.Create(sharePointSettings.SpoTenantUrl, credential, clientOptions);

      ///////////////////////////////////////
      //
      // Setup is complete, run the sample
      //
      //////////////////////////////////////

      try
      {
        var hubSites = await spClient[sharePointSettings.ServerRelativeSiteUrl]._api.HubSites.GetAsync();

        Console.WriteLine($"HubSite count: {hubSites?.Value?.Count ?? 0}");
        Console.WriteLine($"First hub title: {hubSites?.Value?[0]?.Title ?? "<null>"}");
        Console.WriteLine();
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
