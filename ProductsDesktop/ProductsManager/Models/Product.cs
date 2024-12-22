namespace ProductsManager.Models;

public sealed class Product
{
    public int Id { get; set; }
    public required string Name { get; init; }
    public decimal Price { get; set; }
}