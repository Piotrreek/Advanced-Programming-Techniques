using Products.Application.Abstractions;

namespace Products.Application.Features.Products.CreateProduct;

public sealed record CreateProduct(
    string Name,
    int Quantity,
    decimal Price,
    string? Description
) : ICommand;