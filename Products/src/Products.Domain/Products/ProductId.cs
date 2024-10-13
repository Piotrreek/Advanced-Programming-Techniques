namespace Products.Domain.Products;

public sealed record ProductId
{
    public int Value { get; }

    private ProductId(int value)
    {
        Value = value;
    }

    public static ProductId Create(int value)
        => new(value);

    public static implicit operator int(ProductId productId) => productId.Value;

    public static implicit operator ProductId(int value) => Create(value);
}