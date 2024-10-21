using System.Text.Json.Serialization;
using ProductsManager.Specification;

namespace ProductsManager.Models;

public sealed class ProductDetails
{
    [JsonInclude] public int Id { get; private set; }
    [JsonInclude] public string Name { get; private set; }
    [JsonInclude] public decimal Price { get; private set; }
    [JsonInclude] public int Quantity { get; private set; }
    [JsonInclude] public string? Description { get; private set; }
    [JsonInclude] public bool Available { get; private set; }

    private ProductDetails(
        string name,
        decimal price,
        int quantity,
        string? description
    )
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        Description = description;
        Available = Quantity > 0;
    }

    [JsonConstructor]
    private ProductDetails()
    {
    }

    public static Result Create(string? name, decimal? price, int? quantity, string? description)
    {
        var errors = new List<string>();
        CheckRule(new ProductNameCannotBeEmptyRule(name), errors);
        CheckRule(new ProductNameMustContainOnlyLettersAndNumbersRule(name), errors);
        CheckRule(new ProductNameHasMinimumLengthOf3CharactersRule(name), errors);
        CheckRule(new ProductNameHasMaximumLengthOf20CharactersRule(name), errors);
        CheckRule(new ProductQuantityMustBeGreaterOrEqualToZeroRule(quantity), errors);
        CheckRule(new ProductPriceIsGreaterOrEqualToMinimumValueRule(price), errors);

        if (errors.Count > 0)
        {
            return Result.Failure(errors.ToArray());
        }

        var product = new ProductDetails(name!, price!.Value, quantity!.Value, description);

        return Result.Success(product);
    }

    private static void CheckRule(IRule rule, List<string> errors)
    {
        if (!rule.IsSatisfied())
        {
            errors.Add(rule.ErrorMessage);
        }
    }
}