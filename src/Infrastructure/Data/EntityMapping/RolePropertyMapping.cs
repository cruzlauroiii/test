using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.BusinessObjects;

namespace Infrastructure.Data.EntityMapping;

public class RolePropertyMapping : IEntityTypeConfiguration<RoleProperty>
{
    public void Configure(EntityTypeBuilder<RoleProperty> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Key).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Value).IsRequired().HasMaxLength(500);
        
        builder.HasOne(e => e.Role)
            .WithMany(e => e.Properties)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasIndex(e => new { e.RoleId, e.Key }).IsUnique();
    }
}