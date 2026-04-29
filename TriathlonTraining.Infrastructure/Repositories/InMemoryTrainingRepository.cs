using System.Collections.Concurrent;
using TriathlonTraining.Domain.Entities;
using TriathlonTraining.Domain.Enums;
using TriathlonTraining.Domain.Interfaces;

namespace TriathlonTraining.Infrastructure.Repositories;

public class InMemoryTrainingRepository : ITrainingRepository
{
    private readonly ConcurrentDictionary<Guid, Training> _trainings = new();

    public InMemoryTrainingRepository()
    {
        SeedSampleData();
    }

    private void SeedSampleData()
    {
        var sampleTrainings = new[]
        {
            new Training
            {
                Id = Guid.NewGuid(),
                Title = "Natacion tecnica",
                SportType = SportType.Natacion,
                TrainingDate = DateTime.UtcNow.AddDays(-10),
                DistanceKm = 1.5,
                Duration = TimeSpan.FromMinutes(45),
                Description = "Sesion de tecnica de brazada",
                AverageHeartRate = 140,
                CreatedAt = DateTime.UtcNow
            },
            new Training
            {
                Id = Guid.NewGuid(),
                Title = "Ciclismo fondo",
                SportType = SportType.Ciclismo,
                TrainingDate = DateTime.UtcNow.AddDays(-8),
                DistanceKm = 40,
                Duration = TimeSpan.FromHours(1).Add(TimeSpan.FromMinutes(30)),
                Description = "Ruta larga por carretera",
                AverageHeartRate = 150,
                CreatedAt = DateTime.UtcNow
            },
            new Training
            {
                Id = Guid.NewGuid(),
                Title = "Carrera suave",
                SportType = SportType.Atletismo,
                TrainingDate = DateTime.UtcNow.AddDays(-6),
                DistanceKm = 8,
                Duration = TimeSpan.FromMinutes(50),
                Description = "Trote recuperativo",
                AverageHeartRate = 135,
                CreatedAt = DateTime.UtcNow
            },
            new Training
            {
                Id = Guid.NewGuid(),
                Title = "Fuerza tren superior",
                SportType = SportType.Gimnasio,
                TrainingDate = DateTime.UtcNow.AddDays(-5),
                DistanceKm = 0,
                Duration = TimeSpan.FromMinutes(60),
                Description = "Pecho, espalda y hombros",
                AverageHeartRate = 120,
                CreatedAt = DateTime.UtcNow
            },
            new Training
            {
                Id = Guid.NewGuid(),
                Title = "Natacion intervalos",
                SportType = SportType.Natacion,
                TrainingDate = DateTime.UtcNow.AddDays(-4),
                DistanceKm = 2.0,
                Duration = TimeSpan.FromMinutes(50),
                Description = "10x100m a ritmo medio",
                AverageHeartRate = 160,
                CreatedAt = DateTime.UtcNow
            },
            new Training
            {
                Id = Guid.NewGuid(),
                Title = "Ciclismo intervalos",
                SportType = SportType.Ciclismo,
                TrainingDate = DateTime.UtcNow.AddDays(-2),
                DistanceKm = 25,
                Duration = TimeSpan.FromMinutes(75),
                Description = "5x5min a alta intensidad",
                AverageHeartRate = 165,
                CreatedAt = DateTime.UtcNow
            },
            new Training
            {
                Id = Guid.NewGuid(),
                Title = "Fuerza tren inferior",
                SportType = SportType.Gimnasio,
                TrainingDate = DateTime.UtcNow.AddDays(-1),
                DistanceKm = 0,
                Duration = TimeSpan.FromMinutes(55),
                Description = "Sentadillas y peso muerto",
                AverageHeartRate = 130,
                CreatedAt = DateTime.UtcNow
            },
            new Training
            {
                Id = Guid.NewGuid(),
                Title = "Carrera tempo",
                SportType = SportType.Atletismo,
                TrainingDate = DateTime.UtcNow,
                DistanceKm = 10,
                Duration = TimeSpan.FromMinutes(45),
                Description = "Carrera a ritmo constante",
                AverageHeartRate = 155,
                CreatedAt = DateTime.UtcNow
            }
        };

        foreach (var training in sampleTrainings)
        {
            _trainings[training.Id] = training;
        }
    }

    public Task<Training?> GetByIdAsync(Guid id)
    {
        _trainings.TryGetValue(id, out var training);
        return Task.FromResult(training);
    }

public Task<IEnumerable<Training>> GetAllAsync()
{
    return Task.FromResult<IEnumerable<Training>>(_trainings.Values.OrderBy(t => t.TrainingDate));
}

public Task<IEnumerable<Training>> GetByDateAsync(DateTime date)
{
    var trainings = _trainings.Values
        .Where(t => t.TrainingDate.Date == date.Date)
        .OrderBy(t => t.TrainingDate)
        .AsEnumerable();
    return Task.FromResult<IEnumerable<Training>>(trainings);
}

public Task<IEnumerable<Training>> GetBySportTypeAsync(SportType sportType)
{
    var trainings = _trainings.Values
        .Where(t => t.SportType == sportType)
        .OrderBy(t => t.TrainingDate);
    return Task.FromResult<IEnumerable<Training>>(trainings);
}

public Task<IEnumerable<Training>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
{
    var trainings = _trainings.Values
        .Where(t => t.TrainingDate.Date >= startDate.Date && t.TrainingDate.Date <= endDate.Date)
        .OrderBy(t => t.TrainingDate)
        .AsEnumerable();
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
