namespace ProductsManager.Models;

public interface IProductService
{
    Task<ProductDetails?> GetProduct(int id);
    Task<List<Product>> GetProducts();
    Task Add(string? name, int? quantity, decimal? price, string? description);
    Task Update(int id, string? name, int? quantity, decimal? price, string? description);
}