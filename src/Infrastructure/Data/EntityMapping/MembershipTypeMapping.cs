using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.BusinessObjects;

namespace Infrastructure.Data.EntityMapping;

public class MembershipTypeMapping : IEntityTypeConfiguration<MembershipType>
{
    public void Configure(EntityTypeBuilder<MembershipType> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.MembershipTypeName).IsRequired().HasMaxLength(50);
        
        builder.HasOne(e => e.Staff)
            .WithMany()
            .HasForeignKey(e => e.RemoteStaffId)
            .HasPrincipalKey(e => e.StaffId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}