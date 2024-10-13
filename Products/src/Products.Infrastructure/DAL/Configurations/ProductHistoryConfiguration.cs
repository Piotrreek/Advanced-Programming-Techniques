using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Products;
using Products.Infrastructure.DAL.Audit;

namespace Products.Infrastructure.DAL.Configurations;

internal sealed class ProductHistoryConfiguration : IEntityTypeConfiguration<ProductHistory>
{
    public void Configure(EntityTypeBuilder<ProductHistory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ProductId)
            .HasConversion(x => x.Value, id => ProductId.Create(id));

        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.ProductId)
            .IsUnique(false);
    }
}