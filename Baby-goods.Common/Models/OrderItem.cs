public class OrderItem
{
    public Guid Id { get; }
    public Order Order { get; }
    public Product Product { get; }
    public int Quantity { get; }
    public decimal Price { get; }
    public DateTime CreatedAt { get; }

    public OrderItem(
        Order order, 
        Product product, 
        int quantity,
        decimal price,
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
        Price = price;
        CreatedAt = DateTime.UtcNow;
    }
}