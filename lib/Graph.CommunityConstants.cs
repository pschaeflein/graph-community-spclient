﻿namespace Graph.Community
{
  public static class SPCommunityConstants
  {
    public static class Library
    {
      /// The key for the SDK version header.
      internal static readonly string VersionHeaderName = SPCommunityConstants.Headers.LibraryVersionHeaderName;

      /// The version for current assembly.
      internal static string AssemblyVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(SPCommunityConstants).Assembly.Location).FileVersion;

      /// The value for the SDK version header.
      internal static string VersionHeaderValue = $"dotnet-{AssemblyVersion}";
    }

    public static class Serialization
    {
      internal const string ODataType = "odata.type";
    }

    public static class Headers
    {
      /// Library Version header
      public const string LibraryVersionHeaderName = "KiotaSharePointLibraryVersion";

      /// Library Version header
      public const string LibraryVersionHeaderValueFormatString = "dotnet-{0}.{1}.{2}";
    }

    public static class TelemetryProperties
    {
      public const string ResourceUri = nameof(ResourceUri);
      public const string RequestMethod = nameof(RequestMethod);
      public const string ClientRequestId = nameof(ClientRequestId);
      public const string ResponseStatus = nameof(ResponseStatus);
      public const string RawErrorResponse = nameof(RawErrorResponse);
      public const string AuthenticationProvider = nameof(AuthenticationProvider);
      public const string TokenCredential = nameof(TokenCredential);
      public const string LoggingHandler = nameof(LoggingHandler);
      public const string ExtensionMethod = nameof(ExtensionMethod);
    }
  }
}
