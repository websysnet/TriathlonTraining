using TriathlonTraining.Application.DTOs;
using TriathlonTraining.Domain.Enums;

namespace TriathlonTraining.Application.Interfaces;

public interface ITrainingService
{
    Task<TrainingDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<TrainingDto>> GetAllAsync();
    Task<IEnumerable<TrainingDto>> GetByDateAsync(DateTime date);
    Task<IEnumerable<TrainingDto>> GetBySportTypeAsync(SportType sportType);
    Task<TrainingDto> CreateAsync(CreateTrainingDto dto);
    Task<TrainingDto?> UpdateAsync(Guid id, UpdateTrainingDto dto);
    Task<bool> DeleteAsync(Guid id);
}
