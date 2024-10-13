using Products.Application.Abstractions;
using Products.Application.Common.Exceptions;
using Products.Application.Features.Products.DTO;
using Products.Application.Features.Products.Extensions;
using Products.Domain.Products.Abstractions;

namespace Products.Application.Features.Products.GetProduct;

internal sealed class GetProductHandler : IQueryHandler<GetProduct, ProductDetailsDto>
{
    private readonly IProductRepository _productRepository;

    public GetProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDetailsDto> Handle(GetProduct request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException();
        }

        return product.AsDetailsDto();
    }
}