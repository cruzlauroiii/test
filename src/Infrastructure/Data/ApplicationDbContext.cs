using Microsoft.EntityFrameworkCore;
using Domain.Entities;

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

        // Configure Staff entity
        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Username).IsUnique();
            entity.HasIndex(e => e.StaffId).IsUnique();
            entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.HashedPassword).IsRequired();
            entity.Property(e => e.PrimaryCompany).HasMaxLength(100);
        });

        // Configure Role entity
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(200);
        });

        // Configure StaffRole many-to-many relationship
        modelBuilder.Entity<StaffRole>(entity =>
        {
            entity.HasKey(e => new { e.StaffId, e.RoleId });
            
            entity.HasOne(e => e.Staff)
                .WithMany(e => e.StaffRoles)
                .HasForeignKey(e => e.StaffId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.Role)
                .WithMany(e => e.StaffRoles)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure RoleProperty entity
        modelBuilder.Entity<RoleProperty>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Key).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Value).IsRequired().HasMaxLength(500);
            
            entity.HasOne(e => e.Role)
                .WithMany(e => e.Properties)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasIndex(e => new { e.RoleId, e.Key }).IsUnique();
        });

        // Configure Membership entity
        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.MembershipNo).IsRequired().HasMaxLength(50);
            entity.Property(e => e.MemberPassword).IsRequired().HasMaxLength(100);
            entity.Property(e => e.MembershipType).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Company).HasMaxLength(100);
            entity.Property(e => e.PrimaryCompany).HasMaxLength(100);
            entity.Property(e => e.CompanyGroup).HasMaxLength(100);
            entity.Property(e => e.MainLogoLocation).HasMaxLength(200);
            entity.Property(e => e.ReportLogoLocation).HasMaxLength(200);
            
            entity.HasOne(e => e.Staff)
                .WithMany(e => e.Memberships)
                .HasForeignKey(e => e.RemoteStaffId)
                .HasPrincipalKey(e => e.StaffId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.Contact)
                .WithMany(e => e.Memberships)
                .HasForeignKey(e => e.MemberId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure MembershipType entity
        modelBuilder.Entity<MembershipType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.MembershipTypeName).IsRequired().HasMaxLength(50);
            
            entity.HasOne(e => e.Staff)
                .WithMany()
                .HasForeignKey(e => e.RemoteStaffId)
                .HasPrincipalKey(e => e.StaffId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure Contact entity
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.AssignedCompany).HasMaxLength(100);
            entity.Property(e => e.Company).HasMaxLength(100);
            entity.Property(e => e.CompanyGroup).HasMaxLength(100);
            
            entity.HasOne(e => e.AssociatedCompany)
                .WithMany(e => e.Contacts)
                .HasForeignKey(e => e.AssignedCompany)
                .HasPrincipalKey(e => e.CompanyCode)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // Configure AssociatedCompany entity
        modelBuilder.Entity<AssociatedCompany>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.CompanyCode).IsUnique();
            entity.Property(e => e.CompanyCode).IsRequired().HasMaxLength(50);
            entity.Property(e => e.MainLogoLocation).HasMaxLength(200);
            entity.Property(e => e.ReportLogoLocation).HasMaxLength(200);
        });

        // Configure IPadUserOption entity
        modelBuilder.Entity<IPadUserOption>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.StaffId).IsUnique();
            
            entity.HasOne(e => e.Staff)
                .WithOne(e => e.IPadUserOption)
                .HasForeignKey<IPadUserOption>(e => e.StaffId)
                .HasPrincipalKey<Staff>(e => e.StaffId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.DeliveryPreStart)
                .WithMany(e => e.IPadUserOptions)
                .HasForeignKey(e => e.CurrentPreStartId)
                .HasPrincipalKey(e => e.PreStartId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure DeliveryPreStart entity
        modelBuilder.Entity<DeliveryPreStart>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.PreStartId).IsUnique();
            entity.Property(e => e.WorkCompany).HasMaxLength(100);
            entity.Property(e => e.TruckId).HasMaxLength(50);
            entity.Property(e => e.TrailerId).HasMaxLength(50);
            entity.Property(e => e.TrailerId2).HasMaxLength(50);
            entity.Property(e => e.TrailerId3).HasMaxLength(50);
        });

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