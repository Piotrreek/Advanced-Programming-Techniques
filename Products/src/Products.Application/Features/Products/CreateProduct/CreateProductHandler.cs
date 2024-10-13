using Products.Application.Abstractions;
using Products.Application.Features.Products.Common.Exceptions;
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
        if (await _productRepository.ExistsAsync(request.Name, cancellationToken))
        {
            throw new ProductWithNameExistsException();
        }

        var product = Product.Create(
            request.Name,
            request.Quantity,
            request.Price,
            request.Description
        );

        await _productRepository.AddAsync(product, cancellationToken);
    }
}