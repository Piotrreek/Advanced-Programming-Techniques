using Products.Domain.Products.Exceptions;

namespace Products.Domain.Products;

public sealed record ProductQuantity
{
    public int Value { get; }

    private ProductQuantity(int value)
    {
        Value = value;
    }

    public static ProductQuantity Create(int value)
    {
        if (value < 0)
        {
            throw new InvalidProductQuantityException(Errors.QuantityNegative);
        }

        return new ProductQuantity(value);
    }

    public static implicit operator int(ProductQuantity productQuantity) => productQuantity.Value;

    public static implicit operator ProductQuantity(int productQuantity) => Create(productQuantity);
}