using Azure.Identity;
using Graph.Community.Item._api.SiteScriptUtility.CreateSiteScript;
using Graph.Community.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
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
      var WebUrl = $"{sharePointSettings.SpoTenantUrl}/{sharePointSettings.ServerRelativeSiteUrl}";


      var title = "'Green Theme'";
      var description = "'Apply the Green Theme'";


      // Not defining objects for all the actions (that is Microsoft's job).
      //
      // Instead, use Kiota serialization to pass in a JSON string

      var scriptJson = "{\"$schema\": \"schema.json\",\"actions\": [{\"verb\": \"applyTheme\",\"themeName\": \"Green\"}],\"bindata\": { },\"version\": 1}";

      // 1st, get a System.Text.Json.JsonDocument
      using var jsonDocument = JsonDocument.Parse(scriptJson);

      // 2nd, initialize a Kiota IParseNode
      var parseNode = new JsonParseNode(jsonDocument.RootElement);

      // 3rd, parse the node into the required type
      var requestBody = parseNode.GetObjectValue(CreateSiteScriptPostRequestBody.CreateFromDiscriminatorValue);  


      try
      {
        var createdScript = await spClient[sharePointSettings.ServerRelativeSiteUrl]._api
                                    .SiteScriptUtility
                                    .CreateSiteScript
                                    .PostAsync(
                                      body: requestBody,
                                      requestConfiguration: r =>
                                      {
                                        r.QueryParameters.Title = title;
                                        r.QueryParameters.Description = description;
                                      }
                                     );

        var createSiteDesignRequest = new CreateSiteDesignRequest
        {
          Info = new()
          {
            Title = "Green Theme",
            Description = "Apply the Green theme",
            SiteScriptIds = [createdScript!.Id!.Value.ToString()],
            WebTemplate = "64"
          }
        };

        var createdDesign = await spClient[sharePointSettings.ServerRelativeSiteUrl]._api
                                    .SiteScriptUtility
                                    .CreateSiteDesign
                                    .PostAsync(createSiteDesignRequest);

        var applySiteDesignRequest = new ApplySiteDesignRequest
        {
          SiteDesignId = createdDesign!.Id,
          WebUrl = WebUrl
        };

        var applySiteDesignResponse = await spClient[sharePointSettings.ServerRelativeSiteUrl]._api
                                              .SiteScriptUtility
                                              .ApplySiteDesign
                                              .PostAsync(applySiteDesignRequest);


        foreach (var outcome in applySiteDesignResponse!.Value!)
        {
          Console.WriteLine(outcome.OutcomeText);
        }

      }
      catch (Exception ex)
      {

        Console.WriteLine(ex.Message);
      }


      Console.WriteLine("Press enter to show log");
      Console.ReadLine();
      Console.WriteLine();
      var log = logger.GetLog();
      Console.WriteLine(log);

    }
  }
}
