using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Products;
using Products.Infrastructure.DAL.Audit;

namespace Products.Infrastructure.DAL.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product",
            tableBuilder =>
            {
                tableBuilder.HasCheckConstraint("Product_Name_MinLength",
                    $"""LENGTH("Product"."Name") >= {Constraints.NameMinLength}""");

                tableBuilder.HasCheckConstraint("Product_Quantity_MinValue",
                    """ "Product"."Quantity" >= 0""");

                tableBuilder.HasCheckConstraint("Product_Price_MinValue",
                    $""" "Product"."Price" >= {Constraints.MinPrice}""");
            });

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(x => x.Value, id => ProductId.Create(id));

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, name => ProductName.Create(name))
            .IsRequired()
            .HasMaxLength(Constraints.NameMaxLength);

        builder.Property(x => x.Quantity)
            .HasConversion(x => x.Value, quantity => ProductQuantity.Create(quantity))
            .IsRequired();

        builder.Property(x => x.Price)
            .HasConversion(x => x.Value, product => ProductPrice.Create(product))
            .IsRequired()
            .HasPrecision(8, 2);

        builder.Property(x => x.Description)
            .HasConversion(x => x.Value, description => ProductDescription.Create(description))
            .HasMaxLength(Constraints.DescriptionMaxLength)
            .IsRequired(false);

        builder.Property(x => x.Available)
            .IsRequired();

        builder.Property(x => x.Deleted)
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.HasQueryFilter(x => !x.Deleted);
    }
}