namespace Products.Application.Features.Products.DTO;

public sealed class ProductDto
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}