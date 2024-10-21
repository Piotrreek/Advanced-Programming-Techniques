namespace ProductsManager.Specification;

public sealed class ProductNameHasMaximumLengthOf20CharactersRule : IRule
{
    public string ErrorMessage => "Product name cannot be longer than 20 characters.";

    private readonly string? _productName;

    public ProductNameHasMaximumLengthOf20CharactersRule(string? productName)
    {
        _productName = productName;
    }

    public bool IsSatisfied()
        => _productName?.Length <= 20;
}