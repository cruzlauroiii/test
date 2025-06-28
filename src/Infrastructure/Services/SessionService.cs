using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Domain.Interfaces;
using Application.Interfaces;

namespace Infrastructure.Services;

public class SessionService : ISessionService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly IStaffService _staffService;
    private readonly Dictionary<string, object> _sessionData = new();

    public SessionService(AuthenticationStateProvider authenticationStateProvider, IStaffService staffService)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _staffService = staffService;
    }

    public async Task SetCurrentRoleOnlyAsync(string roleName)
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user?.Identity?.IsAuthenticated == true)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int staffId))
            {
                // Store the current role session data
                _sessionData["CurrentSessionRole"] = roleName;
                _sessionData["SessionStartTime"] = DateTime.UtcNow;
                
                // In a real implementation, this would update the user's roles in the session
                // For now, we'll store it in session data
                _sessionData[$"Staff_{staffId}_SessionRole"] = roleName;
            }
        }
    }

    public string? GetCurrentSessionRole()
    {
        return _sessionData.TryGetValue("CurrentSessionRole", out var role) ? role?.ToString() : null;
    }

    public async Task<bool> HasSessionRoleAsync(string roleName)
    {
        var currentRole = GetCurrentSessionRole();
        return !string.IsNullOrEmpty(currentRole) && currentRole.Equals(roleName, StringComparison.OrdinalIgnoreCase);
    }

    public void ClearSessionRoles()
    {
        _sessionData.Remove("CurrentSessionRole");
        _sessionData.Remove("SessionStartTime");
        
        // Clear all staff session roles
        var keysToRemove = _sessionData.Keys.Where(k => k.StartsWith("Staff_") && k.EndsWith("_SessionRole")).ToList();
        foreach (var key in keysToRemove)
        {
            _sessionData.Remove(key);
        }
    }

    public T? GetSessionData<T>(string key)
    {
        if (_sessionData.TryGetValue(key, out var value) && value is T typedValue)
        {
            return typedValue;
        }
        return default;
    }

    public void SetSessionData<T>(string key, T value)
    {
        if (value != null)
        {
            _sessionData[key] = value;
        }
        else
        {
            _sessionData.Remove(key);
        }
    }
}