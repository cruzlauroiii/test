using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.BusinessObjects;

namespace Infrastructure.Data.EntityMapping;

public class MembershipMapping : IEntityTypeConfiguration<Membership>
{
    public void Configure(EntityTypeBuilder<Membership> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.MembershipNo).HasMaxLength(50);
        
        // Use the main Memberpassword property and ignore the calculated MemberPassword
        builder.Property(e => e.Memberpassword).HasMaxLength(100);
        builder.Ignore(e => e.MemberPassword);
        
        builder.Property(e => e.MembershipType).HasMaxLength(50);
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