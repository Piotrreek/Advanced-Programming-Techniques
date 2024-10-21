using Products.Domain.Products.Exceptions;

namespace Products.Domain.Products;

public sealed record ProductDescription
{
    public string? Value { get; }

    private ProductDescription(string? value)
    {
        Value = value;
    }

    public static ProductDescription Create(string? value)
    {
        if (value?.Length > Constraints.DescriptionMaxLength)
        {
            throw new InvalidProductDescriptionException(Errors.DescriptionMaxLength);
        }

        return new ProductDescription(value);
    }

    public static implicit operator string?(ProductDescription? productDescription) => productDescription?.Value;

    public static implicit operator ProductDescription(string? productDescription) => Create(productDescription);

    public override string? ToString() => Value;
}