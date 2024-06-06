
using Microsoft.OpenApi.Models;

namespace Graph.Community
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers();

      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("Graph.Community.SPInfo", new OpenApiInfo
        {
          Version = "v5.1",
          Title = "Graph.Community Mock SharePoint API"
        });
          options.SchemaFilter<AdditionalPropertiesSchemaFilter>();
      });

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI(options => options.SwaggerEndpoint("Graph.Community.SPInfo/swagger.json", "Graph.Community Mock SharePoint API"));
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}
