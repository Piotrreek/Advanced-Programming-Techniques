using Products.Application.Abstractions;

namespace Products.Application.Features.Products.DeleteProduct;

public sealed record DeleteProduct(int ProductId) : ICommand;