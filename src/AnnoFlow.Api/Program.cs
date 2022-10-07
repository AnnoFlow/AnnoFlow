using AnnoFlow.Api.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var apiVersion = new ApiVersion(1, 0);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger(apiVersion, new OpenApiInfo
{
    Version = $"v{apiVersion.MajorVersion}"
});

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddAnnoFlow();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(builder.Configuration.GetRequiredSection("Cors:Origins").Get<string>())
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var url = $"/swagger/v{apiVersion.MajorVersion}/swagger.json";
        var name = $"{nameof(AnnoFlow)} {apiVersion.MajorVersion}.{apiVersion.MinorVersion}";

        options.SwaggerEndpoint(url, name);
    });
}
else
{
    app.UseHttpsRedirection();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();