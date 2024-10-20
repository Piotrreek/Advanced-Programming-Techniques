namespace ProductsManager.Models;

public sealed class ProductDetails
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }
    public bool Available { get; set; }
}