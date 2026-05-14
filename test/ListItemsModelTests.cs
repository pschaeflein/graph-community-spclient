#nullable disable

using Graph.Community.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Serialization.Json;
using Graph.Community.Item._api.Web.Lists.Item.Items;

namespace Graph.Community.Tests
{
  public class ListItemsModelTests
  {
    [Fact]
    public async Task DeserializeItemsGetResponse()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("Collection_ListItems.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<ItemsGetResponse>(responseStream);

      // ASSERT
      Assert.NotNull(actual);
      Assert.NotNull(actual.Value);
      Assert.Equal(3, actual.Value.Count);
    }

    [Fact]
    public async Task DeserializeListItem()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("SP.ListItem.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<SPListItem>(responseStream);

      // ASSERT
      Assert.NotNull(actual);
      Assert.Equal(3, actual.Id);
      Assert.Equal("All the fields", actual.Title);
      Assert.NotEmpty(actual.AdditionalData);
    }

    [Fact]
    public async Task DeserializeListItem_WithContentType()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("SP.ListItem.WithContentType.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<SPListItem>(responseStream);

      // ASSERT
      Assert.NotNull(actual);
      Assert.Equal(3, actual.Id);
      Assert.Equal("All the fields", actual.Title);
      Assert.NotNull(actual.ContentType);
      Assert.Equal("Site Page", actual.ContentType.Name);
      Assert.Equal("0x0101009D1CB255DA76424F860D91F20E6C411800BC5BD9C5AFC86E4BB6C045740D04F93F", actual.ContentType.StringId);
    }

    [Fact]
    public async Task DeserializeListItem_WithFieldValuesAsText()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("SP.ListItem.WithFieldValuesAsText.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<SPListItem>(responseStream);

      // ASSERT
      Assert.NotNull(actual);
      Assert.Equal(3, actual.Id);
      Assert.Equal("All the fields", actual.Title);
      Assert.NotNull(actual.FieldValuesAsText);
      Assert.NotEmpty(actual.FieldValuesAsText.AdditionalData);
    }

    [Fact]
    public async Task DeserializeListItem_WithAllExpandedProperties()
    {
      // ARRANGE
      var responseStream = ResourceManager.GetEmbeddedResource("SP.ListItem.Full.json");
      ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

      // ACT
      var actual = await KiotaJsonSerializer.DeserializeAsync<SPListItem>(responseStream);

      // ASSERT
      Assert.NotNull(actual);
      Assert.Equal(3, actual.Id);
      Assert.Equal("All the fields", actual.Title);
      Assert.NotNull(actual.ContentType);
      Assert.NotNull(actual.FieldValuesAsText);
      Assert.NotNull(actual.FieldValuesAsHtml);
      Assert.NotNull(actual.FieldValuesForEdit);
    }

    [Fact]
    public async Task SerializeListItem()
    {
      // ARRANGE
      ApiClientBuilder.RegisterDefaultSerializer<JsonSerializationWriterFactory>();
      var listItem = new SPListItem
      {
        Id = 5,
        Title = "New Test Item"
      };

      // ACT
      var json = await KiotaJsonSerializer.SerializeAsStringAsync(listItem);

      // ASSERT
      Assert.Contains("\"Id\":5", json);
      Assert.Contains("\"Title\":\"New Test Item\"", json);
    }

    [Fact]
    public void ListItem_SetsDefaultValues()
    {
      // ACT
      var listItem = new SPListItem();

      // ASSERT
      Assert.NotNull(listItem.AdditionalData);
      Assert.Empty(listItem.AdditionalData);
    }

    [Fact]
    public void ListItem_CanSetAllProperties()
    {
      // ARRANGE
      var contentType = new SPContentType { Name = "Custom Type" };
      var fieldValuesAsText = new SPListItem_FieldValuesAsText();
      var fieldValuesAsHtml = new SPListItem_FieldValuesAsHtml();
      var fieldValuesForEdit = new SPListItem_FieldValuesForEdit();

      // ACT
      var listItem = new SPListItem
      {
        Id = 10,
        Title = "Test Item",
        ContentType = contentType,
        FieldValuesAsText = fieldValuesAsText,
        FieldValuesAsHtml = fieldValuesAsHtml,
        FieldValuesForEdit = fieldValuesForEdit,
      };

      // ASSERT
      Assert.Equal(10, listItem.Id);
      Assert.Equal("Test Item", listItem.Title);
      Assert.Same(contentType, listItem.ContentType);
      Assert.Same(fieldValuesAsText, listItem.FieldValuesAsText);
      Assert.Same(fieldValuesAsHtml, listItem.FieldValuesAsHtml);
      Assert.Same(fieldValuesForEdit, listItem.FieldValuesForEdit);
    }

    [Fact]
    public void ItemsGetResponse_SetsDefaultValues()
    {
      // ACT
      var response = new ItemsGetResponse();

      // ASSERT
      Assert.NotNull(response.AdditionalData);
      Assert.Empty(response.AdditionalData);
    }

    [Fact]
    public void ItemsGetResponse_CanSetValue()
    {
      // ARRANGE
      var items = new List<SPListItem>
      {
        new() { Id = 1, Title = "Item 1" },
        new() { Id = 2, Title = "Item 2" }
      };

      // ACT
      var response = new ItemsGetResponse
      {
        Value = items
      };

      // ASSERT
      Assert.NotNull(response.Value);
      Assert.Equal(2, response.Value.Count);
      Assert.Equal("Item 1", response.Value[0].Title);
      Assert.Equal("Item 2", response.Value[1].Title);
    }
  }
}
