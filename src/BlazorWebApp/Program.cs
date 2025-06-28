using BlazorWebApp.Components;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Domain.Interfaces;
using Application.Interfaces;
using Infrastructure.UseCases.Staff;
using Infrastructure.UseCases.Auth;
using Infrastructure.UseCases.Roles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlazorWebApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();

        // Database
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=staff.db"));

        // Repositories
        builder.Services.AddScoped<IStaffRepository, StaffRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<IRolePropertyRepository, RolePropertyRepository>();
        builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
        builder.Services.AddScoped<IMembershipTypeRepository, MembershipTypeRepository>();
        builder.Services.AddScoped<IContactRepository, ContactRepository>();
        builder.Services.AddScoped<IAssociatedCompanyRepository, AssociatedCompanyRepository>();
        builder.Services.AddScoped<IIPadUserOptionRepository, IPadUserOptionRepository>();
        builder.Services.AddScoped<IDeliveryPreStartRepository, DeliveryPreStartRepository>();

        // Services
        builder.Services.AddScoped<IAuthService, Infrastructure.Services.AuthService>();
        builder.Services.AddScoped<IRoleConfigurationService, Infrastructure.Services.RoleConfigurationService>();
        builder.Services.AddScoped<ISessionService, Infrastructure.Services.SessionService>();
        builder.Services.AddScoped<IStaffService, StaffService>();
        builder.Services.AddScoped<IAuthApplicationService, Infrastructure.UseCases.Auth.AuthService>();
        builder.Services.AddScoped<IRoleService, Infrastructure.UseCases.Roles.RoleService>();
        builder.Services.AddScoped<IMembershipService, Infrastructure.UseCases.Memberships.MembershipService>();
        builder.Services.AddScoped<IMembershipTypeService, Infrastructure.UseCases.MembershipTypes.MembershipTypeService>();
        builder.Services.AddScoped<IContactService, Infrastructure.UseCases.Contacts.ContactService>();
        builder.Services.AddScoped<IAssociatedCompanyService, Infrastructure.UseCases.AssociatedCompanies.AssociatedCompanyService>();
        builder.Services.AddScoped<IIPadUserOptionService, Infrastructure.UseCases.IPadUserOptions.IPadUserOptionService>();
        builder.Services.AddScoped<IDeliveryPreStartService, Infrastructure.UseCases.DeliveryPreStarts.DeliveryPreStartService>();

        // Authentication
        var jwtKey = builder.Configuration["Jwt:Key"] ?? "your-super-secret-key-here-must-be-at-least-32-characters";
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "StaffManagement",
                    ValidAudience = "StaffManagement",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });

        builder.Services.AddAuthorization();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(BlazorWebApp.Client._Imports).Assembly);

        // Ensure database is created
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var authService = scope.ServiceProvider.GetRequiredService<IAuthService>();
            
            context.Database.EnsureCreated();
            await Infrastructure.Data.DatabaseSeeder.SeedAsync(context, authService);
        }

        app.Run();
    }
}
