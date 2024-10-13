using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Products.Domain.Products;
using Products.Infrastructure.DAL.Audit;

namespace Products.Infrastructure.DAL.Interceptors;

internal sealed class AuditProductChangesInterceptor : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;
        if (context is null)
        {
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var productEntries = context.ChangeTracker.Entries<Product>()
            .Where(x => x.State is EntityState.Added or EntityState.Modified)
            .ToList();

        foreach (var productEntry in productEntries)
        {
            if (productEntry.State is EntityState.Added)
            {
                await CreateAuditEntry(productEntry.Entity, context);
                continue;
            }

            await DeactivateOldAuditEntryAndCreateNewOne(productEntry.Entity, context);
        }

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static async Task DeactivateOldAuditEntryAndCreateNewOne(Product product, DbContext context)
    {
        var oldAuditEntry = await context.Set<ProductHistory>()
            .SingleAsync(x => x.ProductId == product.Id && x.IsActive);

        oldAuditEntry.Deactivate();

        await CreateAuditEntry(product, context);
    }

    private static async Task CreateAuditEntry(Product product, DbContext context)
    {
        var productHistory = new ProductHistory(product);
        await context.Set<ProductHistory>().AddAsync(productHistory);
    }
}