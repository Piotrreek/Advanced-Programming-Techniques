namespace Products.Domain.Products;

public static class Constraints
{
    public const decimal MinPrice = 0.01M;
    public const int NameMinLength = 3;
    public const int NameMaxLength = 20;
    public const int DescriptionMaxLength = 300;
}