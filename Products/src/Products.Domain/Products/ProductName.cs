using Products.Domain.Products.Exceptions;

namespace Products.Domain.Products;

public sealed record ProductName
{
    public string Value { get; }

    private ProductName(string value)
    {
        Value = value;
    }

    public static ProductName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidProductNameException(Errors.NameEmpty);
        }

        return value.Length switch
        {
            < Constraints.NameMinLength => throw new InvalidProductNameException(Errors.NameMinLength),
            > Constraints.NameMaxLength => throw new InvalidProductNameException(Errors.NameMaxLength),
            _ => new ProductName(value)
        };
    }

    public static implicit operator string(ProductName name) => name.Value;

    public static implicit operator ProductName(string name) => Create(name);
}