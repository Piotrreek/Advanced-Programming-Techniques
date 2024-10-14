using FluentValidation;
using Products.Domain.Products;

namespace Products.Application.Features.Products.UpdateProduct;

internal sealed class UpdateProductValidator : AbstractValidator<UpdateProduct>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.ProductId)
            .NotNull()
            .WithMessage(Common.Errors.IdEmpty);

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(Errors.NameEmpty)
            .Matches(ProductName.Regex)
            .WithMessage(Errors.NameRegex)
            .MinimumLength(Constraints.NameMinLength)
            .WithMessage(Errors.NameMinLength)
            .MaximumLength(Constraints.NameMaxLength)
            .WithMessage(Errors.NameMaxLength);

        RuleFor(x => x.Quantity)
            .NotNull()
            .WithMessage(Common.Errors.QuantityEmpty)
            .GreaterThanOrEqualTo(0)
            .WithMessage(Errors.QuantityNegative);

        RuleFor(x => x.Price)
            .NotNull()
            .WithMessage(Common.Errors.PriceEmpty)
            .GreaterThanOrEqualTo(Constraints.MinPrice)
            .WithMessage(Errors.PriceMinValue);

        RuleFor(x => x.Description)
            .MaximumLength(Constraints.DescriptionMaxLength)
            .WithMessage(Errors.DescriptionMaxLength);
    }
}