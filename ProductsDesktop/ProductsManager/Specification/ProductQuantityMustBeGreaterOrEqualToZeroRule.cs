namespace ProductsManager.Specification;

public sealed class ProductQuantityMustBeGreaterOrEqualToZeroRule : IRule
{
    public string ErrorMessage => "Product quantity must be greater or equal to zero.";

    private readonly int? _quantity;

    public ProductQuantityMustBeGreaterOrEqualToZeroRule(int? quantity)
    {
        _quantity = quantity;
    }

    public bool IsSatisfied()
        => _quantity is >= 0;
}