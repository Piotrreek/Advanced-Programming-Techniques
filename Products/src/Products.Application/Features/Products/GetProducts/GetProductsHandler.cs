using Products.Application.Abstractions;
using Products.Application.Features.Products.DTO;
using Products.Application.Features.Products.Extensions;
using Products.Domain.Products.Abstractions;

namespace Products.Application.Features.Products.GetProducts;

internal sealed class GetProductsHandler : IQueryHandler<GetProducts, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProducts request, CancellationToken cancellationToken)
        => (await _productRepository.GetAsync(cancellationToken))
            .Select(product => product.AsDto());
}