namespace ProductsManager.Models;

public sealed class Result
{
    public bool IsSuccess { get; }
    public ProductDetails? Product { get; }
    public string[] Errors { get; } = [];

    private Result(bool isSuccess, string[]? errors = null)
    {
        IsSuccess = isSuccess;
        Errors = errors ?? [];
    }

    private Result(bool isSuccess, ProductDetails? product)
    {
        IsSuccess = isSuccess;
        Product = product;
    }

    public static Result Success(ProductDetails? product = null) => new(true, product);
    public static Result Failure(string error) => new(false, [error]);
    public static Result Failure(string[] errors) => new(false, errors);
}