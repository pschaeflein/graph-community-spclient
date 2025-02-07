#nullable disable

using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;
using NSubstitute;
using System.Text.Json;

namespace Graph.Community.Tests
{
  public class RequestResponseSerializationFixture : IDisposable
  {
    private readonly string mockSpoUrl = "https://mock.sharepoint.com";

    public RequestResponseSerializationFixture()
    {
      // This code runs once for the entire test suite

      Adapter = Substitute.For<IRequestAdapter>();
      Adapter.BaseUrl = mockSpoUrl;


      // Add JsonSerializationWriter to serialize Post objects
      Adapter.SerializationWriterFactory.GetSerializationWriter("application/json")
          .Returns(sw => new JsonSerializationWriter());

    }

    public IRequestAdapter Adapter { get; private set; }

    public JsonSerializerOptions SerializerOptions { get; private set; } = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    public async Task<TResult> DeserializeAsync<TResult>(Stream content) where TResult:IParsable
    {
      //var sr = new StreamReader(content);
      //var contentString = sr.ReadToEnd();
      //content.Position = 0;

      //var actualBody = await KiotaJsonSerializer.DeserializeAsync<CreateSiteDesignRequest>(actualRequest?.Content);

      var deserializedContent = (content != null)
        ? await KiotaJsonSerializer.DeserializeAsync<TResult>(content)
        : default;

      return deserializedContent;
    }

    public void Dispose()
    {
      // This code runs once after all tests are finished
    }
  }
}
