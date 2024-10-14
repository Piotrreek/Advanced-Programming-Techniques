namespace Products.Infrastructure.DAL.Audit;

internal sealed class ProductAuditEntry
{
    public int Id { get; private set; }
    public string FieldName { get; private set; }
    public string? OldValue { get; private set; }
    public string? NewValue { get; private set; }

    public ProductAuditEntry(string fieldName, string? oldValue, string? newValue)
    {
        FieldName = fieldName;
        OldValue = oldValue;
        NewValue = newValue;
    }
}