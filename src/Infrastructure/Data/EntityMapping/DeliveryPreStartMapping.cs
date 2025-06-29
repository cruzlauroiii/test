using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.BusinessObjects;

namespace Infrastructure.Data.EntityMapping;

public class DeliveryPreStartMapping : IEntityTypeConfiguration<DeliveryPreStart>
{
    public void Configure(EntityTypeBuilder<DeliveryPreStart> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.PreStartId).IsUnique();
        builder.Property(e => e.WorkCompany).HasMaxLength(100);
        builder.Property(e => e.TruckId).HasMaxLength(50);
        builder.Property(e => e.TrailerId).HasMaxLength(50);
        builder.Property(e => e.TrailerId2).HasMaxLength(50);
        builder.Property(e => e.TrailerId3).HasMaxLength(50);
    }
}