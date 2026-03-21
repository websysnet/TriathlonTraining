using TriathlonTraining.Domain.Enums;

namespace TriathlonTraining.Application.DTOs;

public record TrainingDto(
    Guid Id,
    string Title,
    SportType SportType,
    DateTime TrainingDate,
    double DistanceKm,
    TimeSpan Duration,
    string? Description,
    int AverageHeartRate,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);

public record CreateTrainingDto(
    string Title,
    SportType SportType,
    DateTime TrainingDate,
    double DistanceKm,
    TimeSpan Duration,
    string? Description,
    int AverageHeartRate
);

public record UpdateTrainingDto(
    string Title,
    SportType SportType,
    DateTime TrainingDate,
    double DistanceKm,
    TimeSpan Duration,
    string? Description,
    int AverageHeartRate
);
