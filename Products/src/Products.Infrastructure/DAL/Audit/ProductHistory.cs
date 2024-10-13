using Products.Domain.Products;

namespace Products.Infrastructure.DAL.Audit;

internal sealed class ProductHistory
{
    public int Id { get; private set; }
    public bool IsActive { get; private set; }
    public string Name { get; private set; } = default!;
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public string? Description { get; private set; }
    public Product Product { get; private set; } = default!;
    public ProductId ProductId { get; private set; } = default!;

    public ProductHistory(Product product)
    {
        Product = product;
        IsActive = true;
        Name = product.Name;
        Quantity = product.Quantity;
        Price = product.Price;
        Description = product.Description;
    }

    // For EF
    private ProductHistory()
    {
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}