using Products.Application.Abstractions;
using Products.Application.Common.Exceptions;
using Products.Domain.Products.Abstractions;

namespace Products.Application.Features.Products.UpdateProduct;

internal sealed class UpdateProductHandler : ICommandHandler<UpdateProduct>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(UpdateProduct request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException();
        }

        product.Update();

        _productRepository.Update(product);
    }
}