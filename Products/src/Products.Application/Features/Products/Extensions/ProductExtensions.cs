using Products.Application.Features.Products.DTO;
using Products.Domain.Products;

namespace Products.Application.Features.Products.Extensions;

internal static class ProductExtensions
{
    public static ProductDto AsDto(this Product product)
        => new ProductDto
        {
        };

    public static ProductDetailsDto AsDetailsDto(this Product product)
        => new ProductDetailsDto
        {
        };
}