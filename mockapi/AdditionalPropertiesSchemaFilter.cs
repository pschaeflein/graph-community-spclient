using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Graph.Community.SPClient.MockApi
{
  public class AdditionalPropertiesSchemaFilter : ISchemaFilter
  {
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
      if (context.Type.GetCustomAttribute<AllowAdditionalPropertiesAttribute>() != null)
      {
        schema.AdditionalPropertiesAllowed = true;
        schema.AdditionalProperties = new();
      }
    }
  }
}
