public class OrderItem
{
    public Guid Id { get; }
    public Order Order { get; }
    public Product Product { get; }
    public int Quantity { get; private set; }
    public decimal Price { get; }
    public DateTime CreatedAt { get; }
    public DateTime ModifiedAt { get; private set; }

    public OrderItem(
        Order order, 
        Product product, 
        int quantity,
        Guid id = new Guid())
    {
        if (order == null)
        {
            throw new ArgumentNullException($"'{nameof(order)}' connot be null.");
        }

        if (product == null)
        {
            throw new ArgumentNullException($"'{nameof(product)}' connot be null.");
        }

        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException($"'{nameof(quantity)}' cannot be zero or less.");
        }

        Id = id;
        Order = order;
        Product = product;
        Quantity = quantity;
        Price = CalculatePrice();
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
    }

    public void SetQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException($"'{nameof(quantity)}' cannot be zero or less.");
        }

        Quantity = quantity;
        ModifiedAt = DateTime.UtcNow;
    }

    public decimal CalculatePrice()
    {
        return Product.Price * Quantity;
    }
}