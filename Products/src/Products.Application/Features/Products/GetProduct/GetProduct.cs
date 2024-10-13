using Products.Application.Abstractions;
using Products.Application.Features.Products.DTO;

namespace Products.Application.Features.Products.GetProduct;

public record GetProduct(int ProductId) : IQuery<ProductDetailsDto>;