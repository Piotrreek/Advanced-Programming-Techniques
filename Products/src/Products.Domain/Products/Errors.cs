using System.Globalization;

namespace Products.Domain.Products;

public static class Errors
{
    public static string NameEmpty => "Name cannot be empty.";

    public static string NameMinLength
        => $"Product name length must be greater than or equal to {Constraints.NameMinLength}.";

    public static string NameMaxLength
        => $"Product name length must be less or equal to {Constraints.NameMaxLength}.";

    public static string NameRegex
        => "Product name must consist only of letters and numbers.";

    public static string QuantityNegative => "Quantity cannot be negative.";

    public static string PriceMinValue =>
        $"Price must be greater than or equal to {Constraints.MinPrice.ToString(CultureInfo.InvariantCulture)}";

    public static string DescriptionMaxLength
        => $"Product description length must be less or equal to {Constraints.DescriptionMaxLength}.";
}