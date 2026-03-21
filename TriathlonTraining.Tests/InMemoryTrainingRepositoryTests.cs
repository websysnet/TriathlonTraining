using TriathlonTraining.Domain.Entities;
using TriathlonTraining.Domain.Enums;
using TriathlonTraining.Infrastructure.Repositories;

namespace TriathlonTraining.Tests;

public class InMemoryTrainingRepositoryTests
{
    private readonly InMemoryTrainingRepository _repository;

    public InMemoryTrainingRepositoryTests()
    {
        _repository = new InMemoryTrainingRepository();
    }

    [Fact]
    public async Task AddAsync_ShouldAddTraining()
    {
        var training = new Training
        {
            Id = Guid.NewGuid(),
            Title = "Test",
            SportType = SportType.Natacion,
            TrainingDate = DateTime.Today,
            DistanceKm = 2.5,
            Duration = TimeSpan.FromMinutes(45),
            AverageHeartRate = 140,
            CreatedAt = DateTime.UtcNow
        };

        var result = await _repository.AddAsync(training);

        Assert.Equal(training.Id, result.Id);
        var getResult = await _repository.GetByIdAsync(training.Id);
        Assert.NotNull(getResult);
    }

    [Fact]
    public async Task GetByDateAsync_ShouldReturnFilteredTrainings()
    {
        var today = DateTime.Today;
        var training1 = new Training { Id = Guid.NewGuid(), Title = "Today", SportType = SportType.Natacion, TrainingDate = today };
        var training2 = new Training { Id = Guid.NewGuid(), Title = "Yesterday", SportType = SportType.Ciclismo, TrainingDate = today.AddDays(-1) };

        await _repository.AddAsync(training1);
        await _repository.AddAsync(training2);

        var result = await _repository.GetByDateAsync(today);

        Assert.Single(result);
        Assert.Equal("Today", result.First().Title);
    }

    [Fact]
    public async Task GetBySportTypeAsync_ShouldReturnFilteredTrainings()
    {
        var training1 = new Training { Id = Guid.NewGuid(), Title = "Natacion", SportType = SportType.Natacion, TrainingDate = DateTime.Today };
        var training2 = new Training { Id = Guid.NewGuid(), Title = "Ciclismo", SportType = SportType.Ciclismo, TrainingDate = DateTime.Today };

        await _repository.AddAsync(training1);
        await _repository.AddAsync(training2);

        var result = await _repository.GetBySportTypeAsync(SportType.Natacion);

        Assert.Single(result);
        Assert.Equal("Natacion", result.First().Title);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveTraining()
    {
        var training = new Training { Id = Guid.NewGuid(), Title = "Test", SportType = SportType.Atletismo, TrainingDate = DateTime.Today };
        await _repository.AddAsync(training);

        var result = await _repository.DeleteAsync(training.Id);

        Assert.True(result);
        var getResult = await _repository.GetByIdAsync(training.Id);
        Assert.Null(getResult);
    }
}
