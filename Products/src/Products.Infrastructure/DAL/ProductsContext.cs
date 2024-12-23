using Microsoft.EntityFrameworkCore;
using Products.Domain.Products;
using Products.Infrastructure.DAL.Audit;

namespace Products.Infrastructure.DAL;

internal sealed class ProductsContext : DbContext
{
    public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
    {
    }

    public DbSet<Product> Product => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}