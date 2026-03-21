using TriathlonTraining.Domain.Enums;

namespace TriathlonTraining.Domain.Entities;

public class Training
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public SportType SportType { get; set; }
    public DateTime TrainingDate { get; set; }
    public double DistanceKm { get; set; }
    public TimeSpan Duration { get; set; }
    public string? Description { get; set; }
    public int AverageHeartRate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
