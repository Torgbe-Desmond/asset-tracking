using System.Reflection;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Asset_Tracking_Api.Options
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            // Aggregated XML Documentation
            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
            foreach (var xmlPath in xmlFiles)
            {
                options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            }

            // Single-pass SwaggerDoc generation
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                var info = new OpenApiInfo
                {
                    Title = $"Asset Tracking API {description.ApiVersion}",
                    Version = description.ApiVersion.ToString(),
                    Description = "API for managing assets and tracking operations." +
                                  (description.IsDeprecated ? "\n\n**This API version is deprecated.**" : ""),
                    Contact = new OpenApiContact { Name = "Torgbe Desmond", Email = "123torgbe@example.com" }
                };

                options.SwaggerDoc(description.GroupName, info);
            }

            // Routing/Inclusion logic
            options.DocInclusionPredicate((docName, apiDesc) => apiDesc.GroupName == docName);
        }
    }
}