using TriathlonTraining.Application.DTOs;
using TriathlonTraining.Application.Services;
using TriathlonTraining.Domain.Entities;
using TriathlonTraining.Domain.Enums;
using TriathlonTraining.Domain.Interfaces;
using Moq;

namespace TriathlonTraining.Tests;

public class TrainingServiceTests
{
    private readonly Mock<ITrainingRepository> _repositoryMock;
    private readonly TrainingService _service;

    public TrainingServiceTests()
    {
        _repositoryMock = new Mock<ITrainingRepository>();
        _service = new TrainingService(_repositoryMock.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnCreatedTraining()
    {
        var dto = new CreateTrainingDto("Natacion matutina", SportType.Natacion, DateTime.Today, 2.5, TimeSpan.FromMinutes(45), null, 140);
        _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Training>())).ReturnsAsync((Training t) => t);

        var result = await _service.CreateAsync(dto);

        Assert.NotNull(result);
        Assert.Equal(dto.Title, result.Title);
        Assert.Equal(dto.SportType, result.SportType);
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Training>()), Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_WhenExists_ShouldReturnTraining()
    {
        var id = Guid.NewGuid();
        var training = new Training { Id = id, Title = "Test", SportType = SportType.Ciclismo, TrainingDate = DateTime.Today };
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(training);

        var result = await _service.GetByIdAsync(id);

        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
    }

    [Fact]
    public async Task GetByIdAsync_WhenNotExists_ShouldReturnNull()
    {
        var id = Guid.NewGuid();
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((Training?)null);

        var result = await _service.GetByIdAsync(id);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllTrainings()
    {
        var trainings = new List<Training>
        {
            new() { Id = Guid.NewGuid(), Title = "Test 1", SportType = SportType.Natacion, TrainingDate = DateTime.Today },
            new() { Id = Guid.NewGuid(), Title = "Test 2", SportType = SportType.Atletismo, TrainingDate = DateTime.Today }
        };
        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(trainings);

        var result = await _service.GetAllAsync();

        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetBySportTypeAsync_ShouldReturnFilteredTrainings()
    {
        var sportType = SportType.Natacion;
        var trainings = new List<Training>
        {
            new() { Id = Guid.NewGuid(), Title = "Natacion 1", SportType = SportType.Natacion, TrainingDate = DateTime.Today }
        };
        _repositoryMock.Setup(r => r.GetBySportTypeAsync(sportType)).ReturnsAsync(trainings);

        var result = await _service.GetBySportTypeAsync(sportType);

        Assert.Single(result);
        Assert.All(result, t => Assert.Equal(SportType.Natacion, t.SportType));
    }

    [Fact]
    public async Task UpdateAsync_WhenExists_ShouldReturnUpdatedTraining()
    {
        var id = Guid.NewGuid();
        var existing = new Training { Id = id, Title = "Old", SportType = SportType.Natacion, TrainingDate = DateTime.Today, CreatedAt = DateTime.UtcNow };
        var dto = new UpdateTrainingDto("Updated", SportType.Ciclismo, DateTime.Today, 50, TimeSpan.FromHours(2), "Updated desc", 150);
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(existing);
        _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<Training>())).ReturnsAsync((Training t) => t);

        var result = await _service.UpdateAsync(id, dto);

        Assert.NotNull(result);
        Assert.Equal("Updated", result.Title);
        Assert.Equal(SportType.Ciclismo, result.SportType);
        Assert.NotNull(result.UpdatedAt);
    }

    [Fact]
    public async Task UpdateAsync_WhenNotExists_ShouldReturnNull()
    {
        var id = Guid.NewGuid();
        var dto = new UpdateTrainingDto("Updated", SportType.Ciclismo, DateTime.Today, 50, TimeSpan.FromHours(2), "Updated desc", 150);
        _repositoryMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((Training?)null);

        var result = await _service.UpdateAsync(id, dto);

        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteAsync_WhenExists_ShouldReturnTrue()
    {
        var id = Guid.NewGuid();
        _repositoryMock.Setup(r => r.DeleteAsync(id)).ReturnsAsync(true);

        var result = await _service.DeleteAsync(id);

        Assert.True(result);
    }

    [Fact]
    public async Task DeleteAsync_WhenNotExists_ShouldReturnFalse()
    {
        var id = Guid.NewGuid();
        _repositoryMock.Setup(r => r.DeleteAsync(id)).ReturnsAsync(false);

        var result = await _service.DeleteAsync(id);

        Assert.False(result);
    }
}
