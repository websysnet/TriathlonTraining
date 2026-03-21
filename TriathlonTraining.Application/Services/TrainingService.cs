using TriathlonTraining.Application.DTOs;
using TriathlonTraining.Application.Interfaces;
using TriathlonTraining.Domain.Entities;
using TriathlonTraining.Domain.Enums;
using TriathlonTraining.Domain.Interfaces;

namespace TriathlonTraining.Application.Services;

public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _repository;

    public TrainingService(ITrainingRepository repository)
    {
        _repository = repository;
    }

    public async Task<TrainingDto?> GetByIdAsync(Guid id)
    {
        var training = await _repository.GetByIdAsync(id);
        return training is null ? null : MapToDto(training);
    }

    public async Task<IEnumerable<TrainingDto>> GetAllAsync()
    {
        var trainings = await _repository.GetAllAsync();
        return trainings.Select(MapToDto);
    }

    public async Task<IEnumerable<TrainingDto>> GetByDateAsync(DateTime date)
    {
        var trainings = await _repository.GetByDateAsync(date);
        return trainings.Select(MapToDto);
    }

    public async Task<IEnumerable<TrainingDto>> GetBySportTypeAsync(SportType sportType)
    {
        var trainings = await _repository.GetBySportTypeAsync(sportType);
        return trainings.Select(MapToDto);
    }

    public async Task<TrainingDto> CreateAsync(CreateTrainingDto dto)
    {
        var training = new Training
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            SportType = dto.SportType,
            TrainingDate = dto.TrainingDate,
            DistanceKm = dto.DistanceKm,
            Duration = dto.Duration,
            Description = dto.Description,
            AverageHeartRate = dto.AverageHeartRate,
            CreatedAt = DateTime.UtcNow
        };

        var created = await _repository.AddAsync(training);
        return MapToDto(created);
    }

    public async Task<TrainingDto?> UpdateAsync(Guid id, UpdateTrainingDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return null;

        existing.Title = dto.Title;
        existing.SportType = dto.SportType;
        existing.TrainingDate = dto.TrainingDate;
        existing.DistanceKm = dto.DistanceKm;
        existing.Duration = dto.Duration;
        existing.Description = dto.Description;
        existing.AverageHeartRate = dto.AverageHeartRate;
        existing.UpdatedAt = DateTime.UtcNow;

        var updated = await _repository.UpdateAsync(existing);
        return MapToDto(updated);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }

    private static TrainingDto MapToDto(Training training) => new(
        training.Id,
        training.Title,
        training.SportType,
        training.TrainingDate,
        training.DistanceKm,
        training.Duration,
        training.Description,
        training.AverageHeartRate,
        training.CreatedAt,
        training.UpdatedAt
    );
}
