using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWebApp.Client;

public static class WebsiteDependency
{
    public static IServiceCollection ConfigureWebsiteDependencies(this IServiceCollection services)
    {
        // Add authorization core
        services.AddAuthorizationCore(options =>
        {
            // Configure policies for each role
            options.AddPolicy("BrokerRole", policy =>
                policy.RequireRole("Broker"));
                
            options.AddPolicy("DriverRole", policy =>
                policy.RequireRole("Driver"));
                
            options.AddPolicy("ForkliftRole", policy =>
                policy.RequireRole("Forklift"));
                
            options.AddPolicy("FumigationRole", policy =>
                policy.RequireRole("Fumigation"));
                
            options.AddPolicy("ITVRole", policy =>
                policy.RequireRole("ITV"));
        });

        return services;
    }
}