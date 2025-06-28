using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Application.Interfaces;
using Infrastructure.UseCases.Staff;
using Infrastructure.UseCases.Auth;
using Infrastructure.UseCases.Roles;
using Infrastructure.UseCases.Memberships;
using Infrastructure.UseCases.MembershipTypes;
using Infrastructure.UseCases.Contacts;
using Infrastructure.UseCases.AssociatedCompanies;
using Infrastructure.UseCases.IPadUserOptions;
using Infrastructure.UseCases.DeliveryPreStarts;

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

        // Add authorization with policies
        builder.Services.ConfigureWebsiteDependencies();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

        // Add application services  
        builder.Services.AddScoped<IStaffService, StaffService>();
        builder.Services.AddScoped<IAuthApplicationService, Infrastructure.UseCases.Auth.AuthService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IMembershipService, MembershipService>();
        builder.Services.AddScoped<IMembershipTypeService, MembershipTypeService>();
        builder.Services.AddScoped<IContactService, ContactService>();
        builder.Services.AddScoped<IAssociatedCompanyService, AssociatedCompanyService>();
        builder.Services.AddScoped<IIPadUserOptionService, IPadUserOptionService>();
        builder.Services.AddScoped<IDeliveryPreStartService, DeliveryPreStartService>();

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
