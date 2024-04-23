using System.Reflection;

namespace Graph.Community.Tests
{
  internal class ResourceManager
  {
    public static Stream GetEmbeddedResource(string resourceFilename)
    {
      var baseNamespace = "Graph.Community.SPClient.Tests";
      var resourcePath = @"Mocks\" + resourceFilename;
      var resourceName = $"{baseNamespace}.{resourcePath.Replace("\\", ".").Replace("/", ".")}";
      var _assembly = System.Reflection.Assembly.GetExecutingAssembly();
      return _assembly.GetManifestResourceStream(resourceName);
    }
    //private static string GetEmbeddedResource(string resourcePath)
    //{
    //  var baseNamespace = "Graph.Community.SPClient.Tests";
    //  var resourceName = $"{baseNamespace}.{resourcePath.Replace("\\", ".").Replace("/", ".")}";
    //  var _assembly = System.Reflection.Assembly.GetExecutingAssembly();
    //  var _textStreamReader = new System.IO.StreamReader(_assembly.GetManifestResourceStream(resourceName));
    //  return _textStreamReader.ReadToEnd();
    //}
  }
}
