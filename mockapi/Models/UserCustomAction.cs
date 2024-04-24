using System.Text.Json.Serialization;

namespace Graph.Community.MockApi.Models
{
  [AllowAdditionalProperties()]
  public class UserCustomAction
  {
    [JsonPropertyName("ClientSideComponentId")]
    public Guid ClientSideComponentId{get;set;}

    [JsonPropertyName("ClientSideComponentProperties")]
    public string? ClientSideComponentProperties{get;set;}

    [JsonPropertyName("CommandUIExtension")]
    public string? CommandUIExtension{get;set;}

    [JsonPropertyName("Description")]
    public string? Description{get;set;}

    [JsonPropertyName("Group")]
    public string? Group{get;set;}

    [JsonPropertyName("HostProperties")]
    public string? HostProperties{get;set;}

    [JsonPropertyName("Id")]
    public Guid Id{get;set;}

    [JsonPropertyName("ImageUrl")]
    public string? ImageUrl{get;set;}

    [JsonPropertyName("Location")]
    public string? Location{get;set;}

    [JsonPropertyName("Name")]
    public string? Name{get;set;}

    [JsonPropertyName("RegistrationId")]
    public string? RegistrationId{get;set;}

    [JsonPropertyName("RegistrationType")]
    public UserCustomActionRegistrationType RegistrationType{get;set;}

    [JsonPropertyName("Scope")]
    public UserCustomActionScope Scope{get;set;}

    [JsonPropertyName("ScriptBlock")]
    public string? ScriptBlock{get;set;}

    [JsonPropertyName("ScriptSrc")]
    public string? ScriptSrc{get;set;}

    [JsonPropertyName("Sequence")]
    public int Sequence{get;set;}

    [JsonPropertyName("Title")]
    public string? Title{get;set;}

    [JsonPropertyName("Url")]
    public string? Url{get;set;}

    [JsonPropertyName("VersionOfUserCustomAction")]
    public string? VersionOfUserCustomAction { get; set; }
  }
}
