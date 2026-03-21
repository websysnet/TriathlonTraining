using System.Net.Http.Json;
using TriathlonTraining.Blazor.Models;

namespace TriathlonTraining.Blazor.Services;

public class TrainingApiService
{
    private readonly HttpClient _httpClient;

    public TrainingApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<TrainingDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/trainings");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<TrainingDto>>() ?? [];
    }

    public async Task<TrainingDto?> GetByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<TrainingDto>($"api/trainings/{id}");
    }

    public async Task<IEnumerable<TrainingDto>> GetByDateAsync(DateTime date)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<TrainingDto>>($"api/trainings/by-date/{date:yyyy-MM-dd}") ?? [];
    }

    public async Task<IEnumerable<TrainingDto>> GetBySportTypeAsync(int sportType)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<TrainingDto>>($"api/trainings/by-sport/{sportType}") ?? [];
    }

    public async Task<TrainingDto?> CreateAsync(CreateTrainingDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/trainings", dto);
        if (!response.IsSuccessStatusCode) return null;
        return await response.Content.ReadFromJsonAsync<TrainingDto>();
    }

    public async Task<TrainingDto?> UpdateAsync(Guid id, UpdateTrainingDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/trainings/{id}", dto);
        if (!response.IsSuccessStatusCode) return null;
        return await response.Content.ReadFromJsonAsync<TrainingDto>();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/trainings/{id}");
        return response.IsSuccessStatusCode;
    }
}
