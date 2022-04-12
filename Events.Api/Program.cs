using System.Text.Json.Serialization;
using Events.Api.Endpoints.Internal;
using Events.Api.Extensions;
using Events.Api.Middleware;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ApplicationName = "Events.Api"
});


builder.Services.Configure<JsonOptions>(
    options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.IncludeFields = true;
    });

builder.Host.UseSerilog((ctx, lc) => lc
    .Enrich.FromLogContext()
    .WriteTo.Console(new RenderedCompactJsonFormatter()));
builder.Services.AddEndpoints<Program>(builder.Configuration);

builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseSwagger();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseEndpoints<Program>();

app.UseSwaggerUI(options=>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Events API");
    options.RoutePrefix = string.Empty;
});

app.Run();
