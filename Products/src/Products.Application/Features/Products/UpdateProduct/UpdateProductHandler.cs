using Products.Application.Abstractions;
using Products.Application.Features.Products.Common.Exceptions;
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

        if (product.Name != request.Name && await _productRepository.ExistsAsync(request.Name, cancellationToken))
        {
            throw new ProductWithNameExistsException();
        }

        product.UpdateName(request.Name);
        product.UpdateDescription(request.Description);
        product.UpdatePrice(request.Price);
        product.UpdateQuantity(request.Quantity);

        _productRepository.Update(product);
    }
}