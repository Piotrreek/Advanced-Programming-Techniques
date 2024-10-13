namespace Products.Domain.Products;

public sealed class Product
{
    public ProductId Id { get; private set; } = default!;

    private Product()
    {
    }

    public static Product Create()
    {
        return new();
    }

    public void Update()
    {
        
    }
}