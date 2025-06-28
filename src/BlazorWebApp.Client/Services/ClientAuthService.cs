using System.Net.Http.Json;
using Application.DTOs;

namespace BlazorWebApp.Client.Services;

public class ClientAuthService
{
    private readonly HttpClient _httpClient;

    public ClientAuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<LoginResponseDto>() 
               ?? throw new InvalidOperationException("Failed to login");
    }

    public async Task LogoutAsync()
    {
        await _httpClient.PostAsync("api/auth/logout", null);
    }
}