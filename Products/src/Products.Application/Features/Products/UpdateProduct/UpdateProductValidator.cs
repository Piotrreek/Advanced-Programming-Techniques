using FluentValidation;

namespace Products.Application.Features.Products.UpdateProduct;

internal sealed class UpdateProductValidator : AbstractValidator<UpdateProduct>
{
    public UpdateProductValidator()
    {
    }
}