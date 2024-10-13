using FluentValidation;
using Products.Application.Features.Products.Common;

namespace Products.Application.Features.Products.DeleteProduct;

internal sealed class DeleteProductValidator : AbstractValidator<DeleteProduct>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.ProductId)
            .NotNull()
            .WithMessage(Errors.IdEmpty);
    }
}