using FluentValidation;

namespace Products.Application.Features.Products.CreateProduct;

internal sealed class CreateProductValidator : AbstractValidator<CreateProduct>
{
    public CreateProductValidator()
    {
    }
}