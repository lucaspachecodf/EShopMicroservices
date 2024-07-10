using Eshop.Microservices.Ordering.API;
using Eshop.Microservices.Ordering.Application;
using Eshop.Microservices.Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/", () => "Hello World!");

app.Run();
