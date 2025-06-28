using Infrastructure.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context, IAuthService authService)
    {
        // Check if admin user already exists
        if (context.Staff.Any(s => s.Username == "admin"))
            return;

        // Create default admin user
        var adminUser = new Staff
        {
            Username = "admin",
            PasswordHash = await authService.HashPasswordAsync("admin123"),
            Email = "admin@staffmanagement.com",
            FirstName = "System",
            LastName = "Administrator",
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        context.Staff.Add(adminUser);
        await context.SaveChangesAsync();

        // Assign all roles to admin
        var allRoles = await context.Roles.ToListAsync();
        foreach (var role in allRoles)
        {
            context.StaffRoles.Add(new StaffRole
            {
                StaffId = adminUser.Id,
                RoleId = role.Id,
                AssignedAt = DateTime.UtcNow,
                IsActive = true
            });
        }

        await context.SaveChangesAsync();
    }
}