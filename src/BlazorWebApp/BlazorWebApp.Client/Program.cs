using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Application.Interfaces;
using Infrastructure.Services.UseCases.Staff;
using Infrastructure.Services.UseCases.Auth;
using Infrastructure.Services.UseCases.Roles;
using Infrastructure.Services.UseCases.Memberships;
using Infrastructure.Services.UseCases.MembershipTypes;
using Infrastructure.Services.UseCases.Contacts;
using Infrastructure.Services.UseCases.AssociatedCompanies;
using Infrastructure.Services.UseCases.IPadUserOptions;
using Infrastructure.Services.UseCases.DeliveryPreStarts;

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
        builder.Services.AddScoped<IStaffService, Infrastructure.Services.UseCases.Staff.StaffService>();
        builder.Services.AddScoped<IAuthApplicationService, Infrastructure.Services.UseCases.Auth.AuthService>();
        builder.Services.AddScoped<IRoleService, Infrastructure.Services.UseCases.Roles.RoleService>();
        builder.Services.AddScoped<IMembershipService, Infrastructure.Services.UseCases.Memberships.MembershipService>();
        builder.Services.AddScoped<IMembershipTypeService, Infrastructure.Services.UseCases.MembershipTypes.MembershipTypeService>();
        builder.Services.AddScoped<IContactService, Infrastructure.Services.UseCases.Contacts.ContactService>();
        builder.Services.AddScoped<IAssociatedCompanyService, Infrastructure.Services.UseCases.AssociatedCompanies.AssociatedCompanyService>();
        builder.Services.AddScoped<IIPadUserOptionService, Infrastructure.Services.UseCases.IPadUserOptions.IPadUserOptionService>();
        builder.Services.AddScoped<IDeliveryPreStartService, Infrastructure.Services.UseCases.DeliveryPreStarts.DeliveryPreStartService>();

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
