using Products.Domain.Products.Exceptions;

namespace Products.Domain.Products;

public sealed record ProductPrice
{
    public decimal Value { get; }

    private ProductPrice(decimal value)
    {
        Value = value;
    }

    public static ProductPrice Create(decimal value)
    {
        if (value < Constraints.MinPrice)
        {
            throw new InvalidProductPriceException(Errors.PriceMinValue);
        }

        return new ProductPrice(value);
    }

    public static implicit operator decimal(ProductPrice productPrice) => productPrice.Value;

    public static implicit operator ProductPrice(decimal productPrice) => Create(productPrice);
}