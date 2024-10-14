using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Products;
using Products.Infrastructure.DAL.Audit;

namespace Products.Infrastructure.DAL.Configurations;

internal sealed class ProductAuditConfiguration : IEntityTypeConfiguration<ProductAudit>
{
    public void Configure(EntityTypeBuilder<ProductAudit> builder)
    {
        builder.ToTable("ProductAudit");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ChangeDate)
            .IsRequired();

        builder.HasMany(x => x.Entries)
            .WithOne()
            .HasForeignKey("ProductAuditId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Entries)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}