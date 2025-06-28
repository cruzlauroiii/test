using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorWebApp.Client.Services;

namespace BlazorWebApp.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        
        // Add the root component
        builder.RootComponents.Add<Components.App>("#app");

        // Configure HttpClient
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        // Add authorization
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

        // Add client services  
        builder.Services.AddScoped<ClientStaffService>();
        builder.Services.AddScoped<ClientAuthService>();
        builder.Services.AddScoped<ClientRoleService>();

        await builder.Build().RunAsync();
    }
}

// Temporary authentication state provider for WebAssembly
public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var anonymous = new System.Security.Claims.ClaimsPrincipal();
        return Task.FromResult(new AuthenticationState(anonymous));
    }
}
