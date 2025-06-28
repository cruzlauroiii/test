using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.EntityMapping;

public class MembershipMapping : IEntityTypeConfiguration<Membership>
{
    public void Configure(EntityTypeBuilder<Membership> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.MembershipNo).IsRequired().HasMaxLength(50);
        builder.Property(e => e.MemberPassword).IsRequired().HasMaxLength(100);
        builder.Property(e => e.MembershipType).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Company).HasMaxLength(100);
        builder.Property(e => e.PrimaryCompany).HasMaxLength(100);
        builder.Property(e => e.CompanyGroup).HasMaxLength(100);
        builder.Property(e => e.MainLogoLocation).HasMaxLength(200);
        builder.Property(e => e.ReportLogoLocation).HasMaxLength(200);
        
        builder.HasOne(e => e.Staff)
            .WithMany(e => e.Memberships)
            .HasForeignKey(e => e.RemoteStaffId)
            .HasPrincipalKey(e => e.StaffId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(e => e.Contact)
            .WithMany(e => e.Memberships)
            .HasForeignKey(e => e.MemberId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}