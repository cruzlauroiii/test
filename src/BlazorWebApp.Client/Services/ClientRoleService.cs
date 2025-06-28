using System.Net.Http.Json;
using Application.DTOs;

namespace BlazorWebApp.Client.Services;

public class ClientRoleService
{
    private readonly HttpClient _httpClient;

    public ClientRoleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<RoleDto>>("api/roles");
        return response ?? Enumerable.Empty<RoleDto>();
    }

    public async Task<RoleDto?> GetRoleByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<RoleDto>($"api/roles/{id}");
    }

    public async Task<RoleDto> CreateRoleAsync(CreateRoleDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/roles", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<RoleDto>() 
               ?? throw new InvalidOperationException("Failed to create role");
    }

    public async Task<RoleDto> UpdateRoleAsync(UpdateRoleDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/roles/{dto.Id}", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<RoleDto>() 
               ?? throw new InvalidOperationException("Failed to update role");
    }

    public async Task<bool> DeleteRoleAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/roles/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<RolePropertyDto> AddRolePropertyAsync(int roleId, CreateRolePropertyDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync($"api/roles/{roleId}/properties", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<RolePropertyDto>() 
               ?? throw new InvalidOperationException("Failed to add role property");
    }

    public async Task<RolePropertyDto> UpdateRolePropertyAsync(UpdateRolePropertyDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/roles/properties/{dto.Id}", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<RolePropertyDto>() 
               ?? throw new InvalidOperationException("Failed to update role property");
    }

    public async Task<bool> DeleteRolePropertyAsync(int propertyId)
    {
        var response = await _httpClient.DeleteAsync($"api/roles/properties/{propertyId}");
        return response.IsSuccessStatusCode;
    }
}