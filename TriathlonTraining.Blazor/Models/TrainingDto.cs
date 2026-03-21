namespace TriathlonTraining.Blazor.Models;

public class TrainingDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int SportType { get; set; }
    public DateTime TrainingDate { get; set; }
    public double DistanceKm { get; set; }
    public TimeSpan Duration { get; set; }
    public string? Description { get; set; }
    public int AverageHeartRate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public string SportTypeName => SportType switch
    {
        1 => "Natacion",
        2 => "Ciclismo",
        3 => "Atletismo",
        _ => "Desconocido"
    };
}

public class CreateTrainingDto
{
    public string Title { get; set; } = string.Empty;
    public int SportType { get; set; }
    public DateTime TrainingDate { get; set; }
    public double DistanceKm { get; set; }
    public TimeSpan Duration { get; set; }
    public string? Description { get; set; }
    public int AverageHeartRate { get; set; }
}

public class UpdateTrainingDto
{
    public string Title { get; set; } = string.Empty;
    public int SportType { get; set; }
    public DateTime TrainingDate { get; set; }
    public double DistanceKm { get; set; }
    public TimeSpan Duration { get; set; }
    public string? Description { get; set; }
    public int AverageHeartRate { get; set; }
}
