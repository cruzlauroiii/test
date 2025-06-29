using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.BusinessObjects;

namespace Infrastructure.Data.EntityMapping;

public class StaffMapping : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Username).IsUnique();
        builder.HasIndex(e => e.StaffId).IsUnique();
        builder.Property(e => e.Username).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
        builder.Property(e => e.PasswordHash).IsRequired();
        builder.Property(e => e.HashedPassword).IsRequired();
        builder.Property(e => e.PrimaryCompany).HasMaxLength(100);
    }
}