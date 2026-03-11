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
            // Include XML comments if they exist (for better documentation)
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            if (File.Exists(xmlPath))
            {
                options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            }

            // Create a Swagger document ONLY for versions that are not deprecated
            // This prevents empty/invalid swagger.json files that cause the "valid version field" error
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                // Skip deprecated versions unless you explicitly want to document them
                if (description.IsDeprecated)
                {
                    continue; // or you can add a "deprecated" badge in the info below
                }

                var info = new OpenApiInfo
                {
                    Title = $"Asset Tracking API {description.ApiVersion}",
                    Version = description.ApiVersion.ToString(),
                    Description = "API for managing assets and tracking operations.",
                    Contact = new OpenApiContact
                    {
                        Name = "Your Name / Team",
                        Email = "support@example.com"
                    }
                };

                // Optional: mark deprecated versions differently if you keep them
                if (description.IsDeprecated)
                {
                    info.Description += "\n\n**This API version is deprecated.** Please use a newer version.";
                }

                options.SwaggerDoc(description.GroupName, info);
            }

            // Important: only include operations that belong to this document/version
            options.DocInclusionPredicate((docName, apiDesc) =>
            {
                return apiDesc.GroupName == docName;
            });

            // Optional: use OpenAPI 3.0.x explicitly (most compatible)
            // options.SupportNonNullableReferenceTypes(); // if you're using nullable reference types

        }
    }
}