using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data.EntityMapping;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Staff> Staff { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<StaffRole> StaffRoles { get; set; }
    public DbSet<RoleProperty> RoleProperties { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<AssociatedCompany> AssociatedCompanies { get; set; }
    public DbSet<IPadUserOption> IPadUserOptions { get; set; }
    public DbSet<DeliveryPreStart> DeliveryPreStarts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply entity configurations
        modelBuilder.ApplyConfiguration(new StaffMapping());
        modelBuilder.ApplyConfiguration(new RoleMapping());
        modelBuilder.ApplyConfiguration(new StaffRoleMapping());
        modelBuilder.ApplyConfiguration(new RolePropertyMapping());
        modelBuilder.ApplyConfiguration(new MembershipMapping());
        modelBuilder.ApplyConfiguration(new MembershipTypeMapping());
        modelBuilder.ApplyConfiguration(new ContactMapping());
        modelBuilder.ApplyConfiguration(new AssociatedCompanyMapping());
        modelBuilder.ApplyConfiguration(new IPadUserOptionMapping());
        modelBuilder.ApplyConfiguration(new DeliveryPreStartMapping());

        // Seed default roles
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Broker", Description = "Broker operations" },
            new Role { Id = 2, Name = "Driver", Description = "Driver operations" },
            new Role { Id = 3, Name = "Forklift", Description = "Forklift operations" },
            new Role { Id = 4, Name = "Fumigation", Description = "Fumigation operations" },
            new Role { Id = 5, Name = "ITV", Description = "ITV operations" }
        );

        // Seed default admin user
        modelBuilder.Entity<Staff>().HasData(
            new Staff 
            { 
                Id = 1,
                StaffId = 1,
                Username = "admin",
                Password = "admin", // Clear text password as specified
                PasswordHash = "$2a$11$JWDJfUdFy0tcI2s1uc1DzuRZNMpoLevBk0189TXbEXjsetwBMqxCy", // BCrypt hash of "admin"
                HashedPassword = "$2a$11$JWDJfUdFy0tcI2s1uc1DzuRZNMpoLevBk0189TXbEXjsetwBMqxCy", // BCrypt hash as specified in requirements
                PrimaryCompany = "Admin",
                Email = "admin@system.local",
                FirstName = "System",
                LastName = "Administrator",
                IsActive = true,
                CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );

        // Assign all roles to admin user
        modelBuilder.Entity<StaffRole>().HasData(
            new StaffRole { StaffId = 1, RoleId = 1, AssignedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true },
            new StaffRole { StaffId = 1, RoleId = 2, AssignedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true },
            new StaffRole { StaffId = 1, RoleId = 3, AssignedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true },
            new StaffRole { StaffId = 1, RoleId = 4, AssignedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true },
            new StaffRole { StaffId = 1, RoleId = 5, AssignedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true }
        );
    }
}