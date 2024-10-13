using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Products;
using Products.Infrastructure.DAL.Audit;

namespace Products.Infrastructure.DAL.Configurations;

internal sealed class ProductHistoryConfiguration : IEntityTypeConfiguration<ProductHistory>
{
    public void Configure(EntityTypeBuilder<ProductHistory> builder)
    {
        builder.ToTable("ProductHistory",
            tableBuilder =>
            {
                tableBuilder.HasCheckConstraint("ProductHistory_Name_MinLength",
                    $"""LENGTH("ProductHistory"."Name") >= {Constraints.NameMinLength}""");

                tableBuilder.HasCheckConstraint("ProductHistory_Quantity_MinValue",
                    """ "ProductHistory"."Quantity" >= 0""");

                tableBuilder.HasCheckConstraint("ProductHistory_Price_MinValue",
                    $""" "ProductHistory"."Price" >= {Constraints.MinPrice}""");
            });

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Constraints.NameMaxLength);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.Price)
            .IsRequired()
            .HasPrecision(8, 2);

        builder.Property(x => x.Description)
            .HasMaxLength(Constraints.DescriptionMaxLength)
            .IsRequired(false);

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