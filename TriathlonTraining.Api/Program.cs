using TriathlonTraining.Api.Endpoints;
using TriathlonTraining.Application.Interfaces;
using TriathlonTraining.Application.Services;
using TriathlonTraining.Domain.Interfaces;
using TriathlonTraining.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<ITrainingRepository, InMemoryTrainingRepository>();
builder.Services.AddScoped<ITrainingService, TrainingService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapTrainingEndpoints();

app.Run();
