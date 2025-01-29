using Azure.Identity;
using Graph.Community.Models;
using Microsoft.Extensions.Options;

namespace Graph.Community.SPClient.Sample
{
  internal class Web
  {
    private readonly AzureAdSettings azureAdSettings;
    private readonly SharePointSettings sharePointSettings;

    public Web(
      IOptions<AzureAdSettings> azureAdOptions,
      IOptions<SharePointSettings> sharePointOptions)
    {
      this.azureAdSettings = azureAdOptions.Value;
      this.sharePointSettings = sharePointOptions.Value;
    }

    public async Task Run(string example)
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
        if (example == "web")
        {
          var web = await spClient[sharePointSettings.ServerRelativeSiteUrl]._api.Web.GetAsync(config =>
          {
            config.QueryParameters.Expand = ["UserCustomActions"];
          });

          Console.WriteLine($"Title: {web?.Title}");
          Console.WriteLine($"Home page: {web?.WelcomePage}");
          Console.WriteLine($"UserCustomAction count: {web?.UserCustomActions?.Count ?? 0}");
          Console.WriteLine();
        }

        if (example == "getFile")
        {
          //var serverRelativePathToFile = $"{sharePointSettings.ServerRelativeSiteUrl}/Shared Documents/Document.docx";

          //var file = await spClient[sharePointSettings.ServerRelativeSiteUrl]._api.Web.GetFileByServerRelativePath.GetAsync(r =>
          //{
          //  // need to wrap the file path in single quotes
          //  r.QueryParameters.Path = $"'{serverRelativePathToFile}'";
          //});

          Guid fileId = new("fccbc75c-0ae4-4700-b9d3-1e4372a7a173");

          var file = await spClient[sharePointSettings.ServerRelativeSiteUrl]._api.Web.GetFileById(fileId).GetAsync();

          Console.WriteLine($"Filename: {file?.Name}");
          Console.WriteLine($"Id: {file?.UniqueId}");
          Console.WriteLine($"Modified: {file?.TimeLastModified}");
          Console.WriteLine();
        }

        if (example == "user")
        {
          if (string.IsNullOrEmpty(this.sharePointSettings?.EnsureUserUPN))
          {
            Console.WriteLine("UPN not set in appsettings.json");
          }
          else
          {
            var requestBody = new EnsureUserRequest() { LogonName = this.sharePointSettings.EnsureUserUPN };
            var user = await spClient[sharePointSettings.ServerRelativeSiteUrl]._api.Web.Ensureuser.PostAsync(requestBody);

            Console.WriteLine($"Title: {user?.Title}");
            Console.WriteLine($"UPN:   {user?.UserPrincipalName}");
          }

        }
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
