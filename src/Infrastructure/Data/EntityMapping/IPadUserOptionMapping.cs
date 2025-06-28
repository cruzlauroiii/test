using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Data.EntityMapping;

public class IPadUserOptionMapping : IEntityTypeConfiguration<IPadUserOption>
{
    public void Configure(EntityTypeBuilder<IPadUserOption> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.StaffId).IsUnique();
        
        builder.HasOne(e => e.Staff)
            .WithOne(e => e.IPadUserOption)
            .HasForeignKey<IPadUserOption>(e => e.StaffId)
            .HasPrincipalKey<Staff>(e => e.StaffId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(e => e.DeliveryPreStart)
            .WithMany(e => e.IPadUserOptions)
            .HasForeignKey(e => e.CurrentPreStartId)
            .HasPrincipalKey(e => e.PreStartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}