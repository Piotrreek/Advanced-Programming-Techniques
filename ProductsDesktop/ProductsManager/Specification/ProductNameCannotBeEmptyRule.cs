namespace ProductsManager.Specification;

public sealed class ProductNameCannotBeEmptyRule : IRule
{
    public string ErrorMessage => "Product name cannot be empty.";

    private readonly string? _productName;

    public ProductNameCannotBeEmptyRule(string? productName)
    {
        _productName = productName;
    }

    public bool IsSatisfied()
        => !string.IsNullOrWhiteSpace(_productName);
}