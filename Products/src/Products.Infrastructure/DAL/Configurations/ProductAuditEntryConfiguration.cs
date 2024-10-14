using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Infrastructure.DAL.Audit;

namespace Products.Infrastructure.DAL.Configurations;

internal sealed class ProductAuditEntryConfiguration : IEntityTypeConfiguration<ProductAuditEntry>
{
    public void Configure(EntityTypeBuilder<ProductAuditEntry> builder)
    {
        builder.ToTable("ProductAuditEntry");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.FieldName)
            .IsRequired();

        builder.Property(x => x.OldValue)
            .IsRequired(false);

        builder.Property(x => x.NewValue)
            .IsRequired(false);

        builder.HasOne<ProductAudit>()
            .WithMany(x => x.Entries)
            .HasForeignKey("ProductAuditId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}