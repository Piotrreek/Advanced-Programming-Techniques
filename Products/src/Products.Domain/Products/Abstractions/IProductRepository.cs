namespace Products.Domain.Products.Abstractions;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken);
    Task<Product?> GetByIdAsync(ProductId productId, CancellationToken cancellationToken);
    Task<List<Product>> GetAsync(CancellationToken cancellationToken);
    void Update(Product product);
}