namespace Graph.Community.Tests
{
  internal class ResourceManager
  {
    public static Stream GetEmbeddedResource(string resourceFilename)
    {
      var baseNamespace = "Graph.Community.SPClient.Tests";
      var resourcePath = @"ExampleResponses\" + resourceFilename;
      var resourceName = $"{baseNamespace}.{resourcePath.Replace("\\", ".").Replace("/", ".")}";
      var _assembly = System.Reflection.Assembly.GetExecutingAssembly();
      return _assembly.GetManifestResourceStream(resourceName);
    }
  }
}
