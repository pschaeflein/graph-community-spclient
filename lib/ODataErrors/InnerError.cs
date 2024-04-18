﻿using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;

namespace Kiota.SharePoint.ODataErrors
{
  public class InnerError : IAdditionalDataHolder, IParsable
  {
    /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
    public IDictionary<string, object> AdditionalData { get; set; }

#nullable enable

    /// <summary>Client request Id as sent by the client application.</summary>
    public string? ClientRequestId { get; set; }

    /// <summary>Date when the error occured.</summary>
    public DateTimeOffset? Date { get; set; }

    /// <summary>The OdataType property</summary>
    public string? OdataType { get; set; }


    /// <summary>Request Id as tracked internally by the service</summary>
    public string? RequestId { get; set; }

#nullable restore

    /// <summary>
    /// Instantiates a new <see cref="InnerError"/> and sets the default values.
    /// </summary>
    public InnerError()
    {
      AdditionalData = new Dictionary<string, object>();
    }

    /// <summary>
    /// Creates a new instance of the appropriate class based on discriminator value
    /// </summary>
    /// <returns>A <see cref="InnerError"/></returns>
    /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
    public static InnerError CreateFromDiscriminatorValue(IParseNode parseNode)
    {
      _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
      return new InnerError();
    }

    /// <summary>
    /// The deserialization information for the current model
    /// </summary>
    /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
    public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
    {
      return new Dictionary<string, Action<IParseNode>>
            {
                {"client-request-id", n => { ClientRequestId = n.GetStringValue(); } },
                {"date", n => { Date = n.GetDateTimeOffsetValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"request-id", n => { RequestId = n.GetStringValue(); } },
            };
    }

    /// <summary>
    /// Serializes information the current object
    /// </summary>
    /// <param name="writer">Serialization writer to use to serialize this model</param>
    public virtual void Serialize(ISerializationWriter writer)
    {
      _ = writer ?? throw new ArgumentNullException(nameof(writer));
      writer.WriteStringValue("client-request-id", ClientRequestId);
      writer.WriteDateTimeOffsetValue("date", Date);
      writer.WriteStringValue("@odata.type", OdataType);
      writer.WriteStringValue("request-id", RequestId);
      writer.WriteAdditionalData(AdditionalData);
    }
  }
}