using Asp.Versioning.ApiExplorer;

namespace Asset_Tracking_Api.Extensions;

public static class SwaggerUiExtensions
{
    public static WebApplication UseSwaggerWithVersionedUi(this WebApplication app)
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    $"Asset Tracking API {description.GroupName.ToUpperInvariant()}");
            }
        });

        return app;
    }
}