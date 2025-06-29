using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.BusinessObjects;

namespace Infrastructure.Data.EntityMapping;

public class AssociatedCompanyMapping : IEntityTypeConfiguration<AssociatedCompany>
{
    public void Configure(EntityTypeBuilder<AssociatedCompany> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.CompanyCode).IsUnique();
        builder.Property(e => e.CompanyCode).IsRequired().HasMaxLength(50);
        builder.Property(e => e.MainLogoLocation).HasMaxLength(200);
        builder.Property(e => e.ReportLogoLocation).HasMaxLength(200);
    }
}