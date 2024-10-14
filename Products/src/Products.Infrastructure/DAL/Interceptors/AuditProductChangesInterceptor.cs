using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        var productAudits = GetProductAudits(context);

        await context.Set<ProductAudit>().AddRangeAsync(productAudits, cancellationToken);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static List<ProductAudit> GetProductAudits(DbContext context)
    {
        var now = DateTimeOffset.UtcNow;

        List<ProductAudit> productAudits = [];
        var entityEntries = context.ChangeTracker.Entries<Product>().Where(x => x.State != EntityState.Unchanged);
        foreach (var entityEntry in entityEntries)
        {
            var audit = new ProductAudit(now, entityEntry.Entity);
            var isAdd = entityEntry.State == EntityState.Added;

            foreach (var property in entityEntry.Properties)
            {
                if (ShouldAuditProperty(property, isAdd))
                {
                    var entry = new ProductAuditEntry(property.Metadata.Name,
                        isAdd ? null : property.OriginalValue?.ToString(), property.CurrentValue?.ToString());

                    audit.AddEntry(entry);
                }
            }

            productAudits.Add(audit);
        }

        return productAudits;
    }

    private static bool ShouldAuditProperty(PropertyEntry property, bool isAdd)
    {
        if (property.Metadata.IsPrimaryKey())
        {
            return false;
        }

        if (isAdd && property.CurrentValue != null)
        {
            return true;
        }

        return property.IsModified && !Equals(property.CurrentValue, property.OriginalValue);
    }
}