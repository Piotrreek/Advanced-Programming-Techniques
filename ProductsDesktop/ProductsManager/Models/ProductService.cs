using System.Net.Http.Json;
using ProductsManager.ViewModels;

namespace ProductsManager.Models;

internal sealed class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:8080/");
    }

    public Task<ProductDetails?> GetProduct(int id)
        => _httpClient.GetFromJsonAsync<ProductDetails>($"products/{id}");

    public Task<List<Product>> GetProducts()
        => _httpClient.GetFromJsonAsync<List<Product>>("products")!;

    public async Task Add(string? name, int? quantity, decimal? price, string? description)
    {
        var product = new ProductDetails
        {
            Name = name,
            Price = price.Value,
            Quantity = quantity.Value,
            Description = description
        };

        await _httpClient.PostAsJsonAsync("products", product);
    }

    public async Task Update(int id, string? name, int? quantity, decimal? price, string? description)
    {
        var product = new ProductDetails
        {
            Name = name,
            Price = price.Value,
            Quantity = quantity.Value,
            Description = description
        };

        await _httpClient.PatchAsJsonAsync($"products/{id}", product);
    }
}