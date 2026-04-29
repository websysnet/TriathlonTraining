using TriathlonTraining.Application.DTOs;
using TriathlonTraining.Application.Interfaces;
using TriathlonTraining.Domain.Enums;

namespace TriathlonTraining.Api.Endpoints;

public static class TrainingEndpoints
{
    public static void MapTrainingEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/trainings").WithTags("Trainings");

        group.MapGet("/", async (ITrainingService service) =>
        {
            var trainings = await service.GetAllAsync();
            return Results.Ok(trainings);
        })
        .WithName("GetAllTrainings")
        .WithDescription("Get all training sessions");

        group.MapGet("/{id:guid}", async (Guid id, ITrainingService service) =>
        {
            var training = await service.GetByIdAsync(id);
            return training is null ? Results.NotFound() : Results.Ok(training);
        })
        .WithName("GetTrainingById")
        .WithDescription("Get a training session by ID");

        group.MapGet("/by-date/{date:datetime}", async (DateTime date, ITrainingService service) =>
        {
            var trainings = await service.GetByDateAsync(date);
            return Results.Ok(trainings);
        })
        .WithName("GetTrainingsByDate")
        .WithDescription("Get training sessions by date");

        group.MapGet("/by-sport/{sportType:int}", async (int sportType, ITrainingService service) =>
        {
            if (!Enum.IsDefined(typeof(SportType), sportType))
                return Results.BadRequest("Invalid sport type");

            var trainings = await service.GetBySportTypeAsync((SportType)sportType);
            return Results.Ok(trainings);
        })
        .WithName("GetTrainingsBySport")
        .WithDescription("Get training sessions by sport type (1=Natacion, 2=Ciclismo, 3=Atletismo, 4=Gimnasio)");

        group.MapPost("/", async (CreateTrainingDto dto, ITrainingService service) =>
        {
            var training = await service.CreateAsync(dto);
            return Results.Created($"/api/trainings/{training.Id}", training);
        })
        .WithName("CreateTraining")
        .WithDescription("Create a new training session");

        group.MapPut("/{id:guid}", async (Guid id, UpdateTrainingDto dto, ITrainingService service) =>
        {
            var training = await service.UpdateAsync(id, dto);
            return training is null ? Results.NotFound() : Results.Ok(training);
        })
        .WithName("UpdateTraining")
        .WithDescription("Update an existing training session");

        group.MapDelete("/{id:guid}", async (Guid id, ITrainingService service) =>
        {
            var deleted = await service.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        })
        .WithName("DeleteTraining")
        .WithDescription("Delete a training session");
    }
}
