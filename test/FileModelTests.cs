#nullable disable

using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;

namespace Graph.Community.Tests
{
  public class FileModelTests
  {
    [Fact]
    public async Task DeserializeFile()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("SP.File.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<Graph.Community.Models.FileObject>(responseStream);

      // ASSERT
      Assert.Equal("", actual.CheckInComment);
      Assert.Equal(2, actual.CheckOutType);
      Assert.Equal(0, actual.CustomizedPageStatus);
      Assert.True(actual.Exists);
      Assert.Equal(1, actual.Level);
      Assert.Equal(1, actual.MajorVersion);
      Assert.Equal(0, actual.MinorVersion);
      Assert.Equal("G&C4_AS_250012272.jpeg", actual.Name);
      Assert.Equal("/sites/mockSite/G&C4_AS_250012272.jpeg", actual.ServerRelativeUrl);
      Assert.Equal(new(2021, 07, 26, 11, 58, 18, new()), actual.TimeCreated);
      Assert.Equal(new(2021, 07, 26, 11, 58, 18, new()), actual.TimeLastModified);
      Assert.Null(actual.Title);
      Assert.Equal("1.0", actual.UIVersionLabel);
      Assert.Equal(new("ffcf9f63-3228-4c02-befa-b6ba387e6cb2"), actual.UniqueId);
      Assert.NotEmpty(actual.AdditionalData);
    }
  }
}
