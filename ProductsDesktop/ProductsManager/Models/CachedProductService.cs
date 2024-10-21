using MonkeyCache.FileStore;

namespace ProductsManager.Models;

public sealed class CachedProductService : IProductService
{
    private readonly IProductService _productService;

    private const string ProductsCacheKey = "products";

    private static string ProductCacheKey(int id) => $"product-{id}";

    public CachedProductService(IProductService productService)
    {
        _productService = productService;
    }

    public Task<ProductDetails> GetProduct(int id)
        => GetOrCreateCacheEntry(ProductCacheKey(id), () => _productService.GetProduct(id), TimeSpan.FromHours(1));

    public Task<List<Product>> GetProducts()
        => GetOrCreateCacheEntry(ProductsCacheKey, () => _productService.GetProducts(), TimeSpan.FromHours(1));

    public async Task<Result> RemoveProduct(int id)
    {
        ClearProductsCache();
        ClearProductCache(id);

        return await _productService.RemoveProduct(id);
    }

    public async Task<Result> Add(string? name, int? quantity, decimal? price, string? description)
    {
        ClearProductsCache();
        return await _productService.Add(name, quantity, price, description);
    }

    public async Task<Result> Update(int id, string? name, int? quantity, decimal? price, string? description)
    {
        ClearProductsCache();
        ClearProductCache(id);

        return await _productService.Update(id, name, quantity, price, description);
    }

    private static async Task<T> GetOrCreateCacheEntry<T>(string key, Func<Task<T>> factory, TimeSpan expiration)
    {
        if (!Barrel.Current.IsExpired(key))
        {
            return Barrel.Current.Get<T>(key: key);
        }

        var result = await factory();
        Barrel.Current.Add(key, result, expiration);

        return result;
    }

    private static void ClearProductCache(int id)
        => Barrel.Current.Empty(ProductCacheKey(id));


    private static void ClearProductsCache()
        => Barrel.Current.Empty(ProductsCacheKey);
}