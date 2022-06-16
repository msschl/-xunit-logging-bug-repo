using System.Diagnostics;

using Microsoft.AspNetCore.HttpOverrides;

using Serilog;
using Serilog.Enrichers.Span;

Activity.DefaultIdFormat = ActivityIdFormat.W3C;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "wwwroot/dist"
});

builder.Host.UseSerilog((context, loggingBuilder) => loggingBuilder
    .ReadFrom.Configuration(context.Configuration, "Logging:Serilog")
    .Enrich.FromLogContext()
    .Enrich.WithSpan()
#if DEBUG
    .WriteTo.Debug()
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
#endif
);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

await app.RunAsync();

// NOTE(markus): For integration testing we need to make the `Program` class public using a partial class declaration
public partial class Program { }