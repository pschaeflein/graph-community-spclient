using Azure.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Community.SPClient.Sample
{
  internal class SiteDesign
  {
    private readonly AzureAdSettings azureAdSettings;
    private readonly SharePointSettings sharePointSettings;

    public SiteDesign(
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

      var scopes = new string[] { $"{sharePointSettings.SpoTenantUrl}/AllSites.FullControl" };
      var WebUrl = $"{sharePointSettings.SpoTenantUrl}{sharePointSettings.ServerRelativeSiteUrl}";

      //var siteScript = new SiteScriptMetadata()
      //{
      //  Title = "Green Theme",
      //  Description = "Apply the Green Theme",
      //  Content = "{\"$schema\": \"schema.json\",\"actions\": [{\"verb\": \"applyTheme\",\"themeName\": \"Green\"}],\"bindata\": { },\"version\": 1}",
      //};

      //try
      //{


      //  var createdScript = await graphServiceClient
      //                              .SharePointAPI(WebUrl)
      //                              .SiteScripts
      //                              .Request()
      //                              .WithScopes(scopes)
      //                              .CreateAsync(siteScript);

      //  var siteDesign = new SiteDesignMetadata()
      //  {
      //    Title = "Green Theme",
      //    Description = "Apply the Green theme",
      //    SiteScriptIds = new System.Collections.Generic.List<Guid>() { new Guid(createdScript.Id) },
      //    WebTemplate = "64" // 64 = Team Site, 68 = Communication Site, 1 = Groupless Team Site
      //  };

      //  var createdDesign = await graphServiceClient
      //                              .SharePointAPI(WebUrl)
      //                              .SiteDesigns
      //                              .Request()
      //                              .WithScopes(scopes)
      //                              .CreateAsync(siteDesign);

      //  var applySiteDesignRequest = new ApplySiteDesignRequest
      //  {
      //    SiteDesignId = createdDesign.Id,
      //    WebUrl = WebUrl
      //  };

      //  var applySiteDesignResponse = await graphServiceClient
      //                                        .SharePointAPI(WebUrl)
      //                                        .SiteDesigns
      //                                        .Request()
      //                                        .WithScopes(scopes)
      //                                        .ApplyAsync(applySiteDesignRequest);

      //  foreach (var outcome in applySiteDesignResponse.CurrentPage)
      //  {
      //    Console.WriteLine(outcome.OutcomeText);
      //  }

      //}
      //catch (Exception ex)
      //{

      //  Console.WriteLine(ex.Message);
      //}


      Console.WriteLine("Press enter to show log");
      Console.ReadLine();
      Console.WriteLine();
      var log = logger.GetLog();
      Console.WriteLine(log);

    }
  }
}
