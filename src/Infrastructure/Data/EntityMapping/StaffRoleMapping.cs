using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.BusinessObjects;

namespace Infrastructure.Data.EntityMapping;

public class StaffRoleMapping : IEntityTypeConfiguration<StaffRole>
{
    public void Configure(EntityTypeBuilder<StaffRole> builder)
    {
        builder.HasKey(e => new { e.StaffId, e.RoleId });
        
        builder.HasOne(e => e.Staff)
            .WithMany(e => e.StaffRoles)
            .HasForeignKey(e => e.StaffId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(e => e.Role)
            .WithMany(e => e.StaffRoles)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}