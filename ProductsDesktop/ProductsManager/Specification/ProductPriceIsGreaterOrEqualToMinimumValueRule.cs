namespace ProductsManager.Specification;

public sealed class ProductPriceIsGreaterOrEqualToMinimumValueRule : IRule
{
    private const decimal MinimumValue = 0.01M;

    public string ErrorMessage => $"Product price must be greater or equal to {MinimumValue}.";

    private readonly decimal? _price;

    public ProductPriceIsGreaterOrEqualToMinimumValueRule(decimal? price)
    {
        _price = price;
    }

    public bool IsSatisfied()
        => _price >= MinimumValue;
}