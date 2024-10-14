using Products.Domain.Products;

namespace Products.Infrastructure.DAL.Audit;

internal sealed class ProductAudit
{
    public int Id { get; private set; }
    public ProductId ProductId { get; private set; } = default!;
    public Product Product { get; private set; } = default!;
    public DateTimeOffset ChangeDate { get; private set; }
    public IReadOnlyCollection<ProductAuditEntry> Entries => _entries;
    private readonly List<ProductAuditEntry> _entries = [];

    public ProductAudit(DateTimeOffset changeDate, Product product)
    {
        ChangeDate = changeDate;
        Product = product;
    }

    // For EF
    private ProductAudit()
    {
    }

    public void AddEntry(ProductAuditEntry entry)
        => _entries.Add(entry);
}