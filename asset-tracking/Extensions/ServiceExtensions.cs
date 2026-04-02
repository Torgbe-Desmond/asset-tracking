using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Asset_Tracking_Api.Extensions;

public static class ServiceExtensions
{
    // ── Swagger with JWT support ──────────────────────────────
    public static IServiceCollection AddSwaggerWithJwt(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
          
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter your JWT token. Example: eyJhbGci..."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id   = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
        });

        return services;
    }

    // ── JWT Authentication ────────────────────────────────────
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
    {
        var jwtSection = config.GetSection("jwtConfig");

        var secret = jwtSection["Key"]
            ?? throw new InvalidOperationException("JWT signing key is not configured in 'JwtConfig:Key'.");

        var issuer = jwtSection["Issuer"];
        var audience = jwtSection["Audience"];

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
       .AddJwtBearer(options =>
       {
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               ValidIssuer = issuer,
               ValidAudience = audience,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
               ClockSkew = TimeSpan.Zero   // optional: strict expiry
           };

           // ← Add this for debugging
           options.Events = new JwtBearerEvents
           {
               OnAuthenticationFailed = context =>
               {
                   Console.WriteLine($"JWT Authentication Failed: {context.Exception.Message}");
                   Console.WriteLine($"Exception Type: {context.Exception.GetType().Name}");
                   if (context.Exception.InnerException != null)
                       Console.WriteLine($"Inner: {context.Exception.InnerException.Message}");
                   return Task.CompletedTask;
               },
               OnTokenValidated = context =>
               {
                   Console.WriteLine("JWT Token Validated Successfully!");
                   return Task.CompletedTask;
               }
           };
       });

        services.AddAuthorization();
        return services;
    }
}
