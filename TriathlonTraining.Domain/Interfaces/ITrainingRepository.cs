using TriathlonTraining.Domain.Entities;
using TriathlonTraining.Domain.Enums;

namespace TriathlonTraining.Domain.Interfaces;

public interface ITrainingRepository
{
    Task<Training?> GetByIdAsync(Guid id);
    Task<IEnumerable<Training>> GetAllAsync();
    Task<IEnumerable<Training>> GetByDateAsync(DateTime date);
    Task<IEnumerable<Training>> GetBySportTypeAsync(SportType sportType);
    Task<IEnumerable<Training>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<Training> AddAsync(Training training);
    Task<Training> UpdateAsync(Training training);
    Task<bool> DeleteAsync(Guid id);
}
