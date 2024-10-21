using System.Text.RegularExpressions;

namespace ProductsManager.Specification;

public sealed class ProductNameMustContainOnlyLettersAndNumbersRule : IRule
{
    public string ErrorMessage => "Product name must contain only letters and numbers.";

    private static Regex Regex { get; } = new("^[a-zA-Z0-9]*$");

    private readonly string? _productName;

    public ProductNameMustContainOnlyLettersAndNumbersRule(string? productName)
    {
        _productName = productName;
    }

    public bool IsSatisfied()
    {
        return _productName is not null && Regex.IsMatch(_productName);
    }
}