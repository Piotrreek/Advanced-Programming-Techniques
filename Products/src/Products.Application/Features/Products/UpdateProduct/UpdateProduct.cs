using Products.Application.Abstractions;

namespace Products.Application.Features.Products.UpdateProduct;

public sealed record UpdateProduct(int ProductId) : ICommand;