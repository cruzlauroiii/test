using System.Net.Http.Json;
using Application.DTOs;

namespace BlazorWebApp.Client.Services;

public class ClientStaffService
{
    private readonly HttpClient _httpClient;

    public ClientStaffService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<StaffDto>> GetAllStaffAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<StaffDto>>("api/staff");
        return response ?? Enumerable.Empty<StaffDto>();
    }

    public async Task<StaffDto?> GetStaffByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<StaffDto>($"api/staff/{id}");
    }

    public async Task<StaffDto> CreateStaffAsync(CreateStaffDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/staff", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<StaffDto>() 
               ?? throw new InvalidOperationException("Failed to create staff");
    }

    public async Task<StaffDto> UpdateStaffAsync(UpdateStaffDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/staff/{dto.Id}", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<StaffDto>() 
               ?? throw new InvalidOperationException("Failed to update staff");
    }

    public async Task<bool> DeleteStaffAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/staff/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync($"api/staff/{dto.StaffId}/change-password", dto);
        return response.IsSuccessStatusCode;
    }
}