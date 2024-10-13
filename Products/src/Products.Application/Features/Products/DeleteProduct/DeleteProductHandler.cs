using Products.Application.Abstractions;
using Products.Application.Features.Products.Common.Exceptions;
using Products.Domain.Products.Abstractions;

namespace Products.Application.Features.Products.DeleteProduct;

internal sealed class DeleteProductHandler : ICommandHandler<DeleteProduct>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(DeleteProduct request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException();
        }

        product.Delete();

        _productRepository.Update(product);
    }
}