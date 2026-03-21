using System.Collections.Concurrent;
using TriathlonTraining.Domain.Entities;
using TriathlonTraining.Domain.Enums;
using TriathlonTraining.Domain.Interfaces;

namespace TriathlonTraining.Infrastructure.Repositories;

public class InMemoryTrainingRepository : ITrainingRepository
{
    private readonly ConcurrentDictionary<Guid, Training> _trainings = new();

    public Task<Training?> GetByIdAsync(Guid id)
    {
        _trainings.TryGetValue(id, out var training);
        return Task.FromResult(training);
    }

    public Task<IEnumerable<Training>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Training>>(_trainings.Values.OrderByDescending(t => t.TrainingDate));
    }

    public Task<IEnumerable<Training>> GetByDateAsync(DateTime date)
    {
        var trainings = _trainings.Values
            .Where(t => t.TrainingDate.Date == date.Date)
            .OrderByDescending(t => t.TrainingDate)
            .AsEnumerable();
        return Task.FromResult<IEnumerable<Training>>(trainings);
    }

    public Task<IEnumerable<Training>> GetBySportTypeAsync(SportType sportType)
    {
        var trainings = _trainings.Values
            .Where(t => t.SportType == sportType)
            .OrderByDescending(t => t.TrainingDate);
        return Task.FromResult<IEnumerable<Training>>(trainings);
    }

    public Task<Training> AddAsync(Training training)
    {
        _trainings[training.Id] = training;
        return Task.FromResult(training);
    }

    public Task<Training> UpdateAsync(Training training)
    {
        _trainings[training.Id] = training;
        return Task.FromResult(training);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        return Task.FromResult(_trainings.TryRemove(id, out _));
    }
}
