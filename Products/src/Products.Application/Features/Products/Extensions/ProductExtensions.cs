using Products.Application.Features.Products.DTO;
using Products.Domain.Products;

namespace Products.Application.Features.Products.Extensions;

internal static class ProductExtensions
{
    public static ProductDto AsDto(this Product product)
        => new()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };

    public static ProductDetailsDto AsDetailsDto(this Product product)
        => new()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
            Description = product.Description,
            Available = product.Available
        };
}