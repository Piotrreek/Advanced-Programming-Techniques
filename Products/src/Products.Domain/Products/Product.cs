namespace Products.Domain.Products;

public sealed class Product
{
    public ProductId Id { get; private set; } = default!;
    public ProductName Name { get; private set; }
    public ProductQuantity Quantity { get; private set; }
    public ProductPrice Price { get; private set; }
    public ProductDescription Description { get; private set; }
    public bool Available { get; private set; }

    private Product(
        ProductName name,
        ProductQuantity quantity,
        ProductPrice price,
        ProductDescription description
    )
    {
        Name = name;
        Quantity = quantity;
        Price = price;
        Description = description;
        Available = quantity > 0;
    }

    public static Product Create(
        ProductName name,
        ProductQuantity quantity,
        ProductPrice price,
        ProductDescription description
    ) => new(name, quantity, price, description);


    public void UpdateName(ProductName name)
    {
        Name = name;
    }

    public void UpdateQuantity(ProductQuantity quantity)
    {
        Quantity = quantity;
    }

    public void UpdatePrice(ProductPrice price)
    {
        Price = price;
    }

    public void UpdateDescription(ProductDescription description)
    {
        Description = description;
    }
}