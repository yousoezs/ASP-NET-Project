using Ocelot.DependencyInjection;
using Ocelot.Middleware;

// Use this class library to set up your Ocelot and gateway for Docker Checkout the docker-compose yaml and ocelot.json

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddOcelot(builder.Environment)
    .AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseOcelot().Wait();

app.Run();
