using MinimalAPIExample.DependencyInjection;
using MinimalAPIExample.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMinimalApiExampleDependencies(builder.Configuration);

var application = builder.Build();

// Configure the HTTP request pipeline.
if (application.Environment.IsDevelopment())
{
    application.UseSwagger();
    application.UseSwaggerUI();
}

application.UseHttpsRedirection();

//Default home endpoint
application.MapGet("/", () => "Hello, .NET 8 Minimal API");

//Map Game Service Routes
application.ConfigureGameServiceEndpoints();

application.Run();
