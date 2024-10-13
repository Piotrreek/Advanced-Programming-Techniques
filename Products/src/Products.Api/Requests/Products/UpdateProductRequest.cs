namespace Products.Api.Requests.Products;

public sealed record UpdateProductRequest(
    string Name,
    int Quantity,
    decimal Price,
    string? Description
);