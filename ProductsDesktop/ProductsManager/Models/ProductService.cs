using System.Net.Http.Json;

namespace ProductsManager.Models;

internal sealed class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:8080/");
    }

    public Task<ProductDetails> GetProduct(int id)
        => _httpClient.GetFromJsonAsync<ProductDetails>($"products/{id}")!;

    public Task<List<Product>> GetProducts()
        => _httpClient.GetFromJsonAsync<List<Product>>("products")!;

    public async Task<Result> RemoveProduct(int id)
    {
        using var response = await _httpClient.DeleteAsync($"products/{id}");

        return response.IsSuccessStatusCode ? Result.Success() : Result.Failure("Failed to remove product");
    }

    public async Task<Result> Add(string? name, int? quantity, decimal? price, string? description)
    {
        var productResult = ProductDetails.Create(name, price, quantity, description);

        if (!productResult.IsSuccess)
        {
            return productResult;
        }

        using var response = await _httpClient.PostAsJsonAsync("products", productResult.Product);

        return response.IsSuccessStatusCode ? Result.Success() : Result.Failure("Failed to add product");
    }

    public async Task<Result> Update(int id, string? name, int? quantity, decimal? price, string? description)
    {
        var productResult = ProductDetails.Create(name, price, quantity, description);

        if (!productResult.IsSuccess)
        {
            return productResult;
        }

        using var response = await _httpClient.PatchAsJsonAsync($"products/{id}", productResult.Product);

        return response.IsSuccessStatusCode ? Result.Success() : Result.Failure("Failed to update product");
    }
}