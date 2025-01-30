#nullable disable

using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;
using Graph.Community.Item._api.Web.Lists;

namespace Graph.Community.Tests
{
  public class ListsModelTests
  {
    [Fact]
    public async Task DeserializeListsGetResponse()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("ListsGetResponse.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<ListsGetResponse>(responseStream);

      // ASSERT
      Assert.Equal(25, actual.Value.Count);
    }

    [Fact]
    public async Task DeserializeList()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("SP.List.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<List>(responseStream);

      // ASSERT
      Assert.Equal(new("37c55620-e302-4caa-9270-73277ab3964d"), actual.Id);
      Assert.Equal("Events", actual.Title);
      Assert.Equal(106, actual.BaseTemplate);
      Assert.Equal(3, actual.Forms.Count);
      Assert.NotEmpty(actual.AdditionalData);
    }

    [Fact]
    public async Task DeserializeForm()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("SP.Form.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<Form>(responseStream);

      // ASSERT
      Assert.Equal(new("dfe567d7-1a60-47d9-96f5-a0c69486a1c9"), actual.Id);
      Assert.Equal(8, actual.FormType);
      Assert.Equal("/sites/mockSite/Lists/Events/NewForm.aspx", actual.ServerRelativeUrl);
    }
  }
}
