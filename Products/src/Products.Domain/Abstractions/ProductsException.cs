namespace Products.Domain.Abstractions;

public abstract class ProductsException : Exception
{
    protected ProductsException(string message) : base(message)
    {
    }
}