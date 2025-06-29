using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.BusinessObjects;

namespace Infrastructure.Data.EntityMapping;

public class ContactMapping : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.AssignedCompany).HasMaxLength(100);
        builder.Property(e => e.Company).HasMaxLength(100);
        builder.Property(e => e.CompanyGroup).HasMaxLength(100);
        
        builder.HasOne(e => e.AssociatedCompany)
            .WithMany(e => e.Contacts)
            .HasForeignKey(e => e.AssignedCompany)
            .HasPrincipalKey(e => e.CompanyCode)
            .OnDelete(DeleteBehavior.SetNull);
    }
}