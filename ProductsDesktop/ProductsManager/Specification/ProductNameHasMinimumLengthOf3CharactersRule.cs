namespace ProductsManager.Specification;

public sealed class ProductNameHasMinimumLengthOf3CharactersRule : IRule
{
    public string ErrorMessage => "Product name must have at least 3 characters.";

    private readonly string? _productName;

    public ProductNameHasMinimumLengthOf3CharactersRule(string? productName)
    {
        _productName = productName;
    }

    public bool IsSatisfied()
        => _productName?.Length >= 3;
}