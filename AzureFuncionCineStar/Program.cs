using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebCinestar.Repositories; 

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();


builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();


builder.Services.AddScoped<CineRepo>();
builder.Services.AddScoped<PeliculaRepo>();

builder.Build().Run();