using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Graph.Community.SPClient.Sample
{
  internal class Program
  {
    static async Task Main(string[] args)
    {
      using var host =
        Host.CreateDefaultBuilder(args)
              .UseContentRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
              .UseEnvironment("Development")
              .ConfigureServices((hostContext, services) =>
              {
                services.AddSingleton<MenuService>();

                services.AddOptions<AzureAdSettings>()
                  .Configure<IConfiguration>((settings, configuration) =>
                  {
                    configuration.GetSection(AzureAdSettings.ConfigurationSectionName).Bind(settings);
                  });

                services.AddOptions<SharePointSettings>()
                  .Configure<IConfiguration>((settings, configuration) =>
                  {
                    configuration.GetSection(SharePointSettings.ConfigurationSectionName).Bind(settings);
                  });


                /*
                 * 
                 * This code is for logging via ILogger
                 * 

                services.AddOptions<DotNetILoggerSettings>()
                  .Configure<IConfiguration>((settings, configuration) =>
                  {
                    // not using app settings, just setting as an example...
                    settings.LogLevel = Microsoft.Extensions.Logging.LogLevel.Information;
                  });


                services.AddTransient<DotNetILoggerHttpMessageLogger>();
                services.AddTransient<DiagnosticsILogger>();
                */

                // Add our sample classes
                services.AddTransient<Diagnostics>();
                services.AddTransient<HubSiteList>();
                services.AddTransient<Web>();
                services.AddTransient<SitePages>();
                //services.AddTransient<SiteGroups>();
                //services.AddTransient<SharePointSearch>();
                //services.AddTransient<SiteDesign>();
                //services.AddTransient<GraphGroupExtensions>();
              })
              .Build();

      await host.StartAsync();

      var menu = host.Services.GetRequiredService<MenuService>();
      menu.StartMenuLoop(host.Services);

      await host.WaitForShutdownAsync();
    }
  }
}
