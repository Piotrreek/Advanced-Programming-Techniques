using Products.Application.Abstractions;
using Products.Application.Features.Products.DTO;

namespace Products.Application.Features.Products.GetProducts;

public record GetProducts : IQuery<IEnumerable<ProductDto>>;