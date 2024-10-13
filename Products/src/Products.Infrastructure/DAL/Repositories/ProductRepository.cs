using Microsoft.EntityFrameworkCore;
using Products.Domain.Products;
using Products.Domain.Products.Abstractions;

namespace Products.Infrastructure.DAL.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly ProductsContext _context;

    public ProductRepository(ProductsContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await _context.Product.AddAsync(product, cancellationToken);
    }

    public Task<Product?> GetByIdAsync(ProductId productId, CancellationToken cancellationToken)
        => _context.Product.FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);

    public Task<List<Product>> GetAsync(CancellationToken cancellationToken)
        => _context.Product.ToListAsync(cancellationToken);

    public Task<bool> ExistsAsync(ProductName productName, CancellationToken cancellationToken)
        => _context.Product.AnyAsync(x => x.Name == productName, cancellationToken);

    public void Update(Product product)
    {
        _context.Product.Update(product);
    }
}