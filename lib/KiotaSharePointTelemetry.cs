using System.Collections.Generic;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace Kiota.SharePoint
{
  internal class KiotaSharePointTelemetry
  {
    private static readonly TelemetryConfiguration telemetryConfiguration = TelemetryConfiguration.CreateDefault();
    private static readonly TelemetryClient telemetryClient;

    static KiotaSharePointTelemetry()
    {
      telemetryConfiguration.ConnectionString= "InstrumentationKey=d882bd7a-a378-4117-bd7c-71fc95a44cd1;IngestionEndpoint=https://centralus-0.in.applicationinsights.azure.com/;LiveEndpoint=https://centralus.livediagnostics.monitor.azure.com/";
      telemetryClient = new TelemetryClient(telemetryConfiguration);
    }

    internal static void LogServiceRequest(
      string resourceUri,
      string clientRequestId,
      System.Net.Http.HttpMethod requestMethod,
      System.Net.HttpStatusCode statusCode,
      string rawResponseContent)
    {
      if (KiotaSharePointClientFactory.TelemetryDisabled)
      {
        return;
      }

      Dictionary<string, string> properties = new Dictionary<string, string>(5)
      {
        { KiotaSharePointConstants.Headers.LibraryVersionHeaderName, KiotaSharePointConstants.Library.AssemblyVersion },
        { KiotaSharePointConstants.TelemetryProperties.ResourceUri, resourceUri },
        { KiotaSharePointConstants.TelemetryProperties.RequestMethod, requestMethod.ToString() },
        { KiotaSharePointConstants.TelemetryProperties.ClientRequestId, clientRequestId },
        { KiotaSharePointConstants.TelemetryProperties.ResponseStatus, $"{statusCode} ({(int)statusCode})" }
      };

      if (!string.IsNullOrEmpty(rawResponseContent))
      {
        properties.Add(KiotaSharePointConstants.TelemetryProperties.RawErrorResponse, rawResponseContent);
      }

      telemetryClient.TrackEvent("KiotaSharePointRequest", properties);
    }
  }
}
