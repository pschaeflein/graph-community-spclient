using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;

namespace Graph.Community
{
  public class ErrorDetails : IAdditionalDataHolder, IParsable
  {
    /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
    public IDictionary<string, object> AdditionalData { get; set; }


#nullable enable

    /// <summary>The code property</summary>
    public string? Code { get; set; }

    /// <summary>The message property</summary>
    public string? Message { get; set; }

    /// <summary>The target property</summary>
    public string? Target { get; set; }

#nullable restore

    /// <summary>
    /// Instantiates a new <see cref="ErrorDetails"/> and sets the default values.
    /// </summary>
    public ErrorDetails()
    {
      AdditionalData = new Dictionary<string, object>();
    }

    /// <summary>
    /// Creates a new instance of the appropriate class based on discriminator value
    /// </summary>
    /// <returns>A <see cref="ErrorDetails"/></returns>
    /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
    public static ErrorDetails CreateFromDiscriminatorValue(IParseNode parseNode)
    {
      _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
      return new ErrorDetails();
    }

    /// <summary>
    /// The deserialization information for the current model
    /// </summary>
    /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
    public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
    {
      return new Dictionary<string, Action<IParseNode>>
      {
        {"code", n => { Code = n.GetStringValue(); } },
        {"message", n => { Message = n.GetStringValue(); } },
        {"target", n => { Target = n.GetStringValue(); } },
      };
    }

    /// <summary>
    /// Serializes information the current object
    /// </summary>
    /// <param name="writer">Serialization writer to use to serialize this model</param>
    public virtual void Serialize(ISerializationWriter writer)
    {
      _ = writer ?? throw new ArgumentNullException(nameof(writer));
      writer.WriteStringValue("code", Code);
      writer.WriteStringValue("message", Message);
      writer.WriteStringValue("target", Target);
      writer.WriteAdditionalData(AdditionalData);
    }
  }
}