using Asset_Tracking.Application;
using Asset_Tracking.Extensions;
using Asset_Tracking_Api.Extensions;
using Asset_Tracking_Api.Middleware;
using Asset_Tracking_Api.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioningWithExplorer(); 
builder.Services.AddSwaggerWithJwt();             
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddApplicationDi(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithVersionedUi();               
}

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();