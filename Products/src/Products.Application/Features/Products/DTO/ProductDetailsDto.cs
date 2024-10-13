namespace Products.Application.Features.Products.DTO;

public sealed class ProductDetailsDto
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required int Quantity { get; init; }
    public required string? Description { get; init; }
    public required bool Available { get; init; }
}