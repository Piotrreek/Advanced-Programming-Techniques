namespace ProductsManager.Models;

public interface IProductService
{
    Task<ProductDetails> GetProduct(int id);
    Task<Result> RemoveProduct(int id);
    Task<List<Product>> GetProducts();
    Task<Result> Add(string? name, int? quantity, decimal? price, string? description);
    Task<Result> Update(int id, string? name, int? quantity, decimal? price, string? description);
}