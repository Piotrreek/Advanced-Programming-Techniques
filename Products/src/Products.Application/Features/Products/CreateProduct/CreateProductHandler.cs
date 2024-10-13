using Products.Application.Abstractions;
using Products.Domain.Products;
using Products.Domain.Products.Abstractions;

namespace Products.Application.Features.Products.CreateProduct;

internal sealed class CreateProductHandler : ICommandHandler<CreateProduct>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        var product = Product.Create();

        await _productRepository.AddAsync(product, cancellationToken);
    }
}