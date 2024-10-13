namespace Products.Api.Requests.Products;

public sealed record CreateProductRequest(
    string Name,
    int Quantity,
    decimal Price,
    string? Description
);