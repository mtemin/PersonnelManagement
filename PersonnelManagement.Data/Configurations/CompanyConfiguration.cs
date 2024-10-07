using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonnelManagement.Domain.Models.Concrete;

namespace PersonnelManagement.Data.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.CompanyId);
        builder.Property(x => x.CompanyId).UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.HasMany(x => x.Expenses)  //harcama
            .WithOne(e => e.Company)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.PersonnelLeaveDays)  //izin günleri
            .WithOne(ld => ld.Company)
            .HasForeignKey(ld => ld.CompanyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Employees)  //çalışan
            .WithOne(e => e.Company)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.NoAction);
                
        builder.ToTable("Companies");

    }
}