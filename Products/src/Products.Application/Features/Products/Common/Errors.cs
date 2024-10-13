namespace Products.Application.Features.Products.Common;

internal static class Errors
{
    public const string ProductNotFound = "Product with specified identifier was not found.";
    public static string QuantityEmpty => "Quantity cannot be empty.";
    public static string PriceEmpty => "Price cannot be empty";
    public static string ProductWithNameExists => "Product with specified name already exists.";
    public static string IdEmpty => "Id cannot be null.";
}