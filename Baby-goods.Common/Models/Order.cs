public class Order
{
    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid AddressId { get; }
    public decimal TotalPrice { get; private set; }
    public DateTime CreatedAt { get; }

    public Order(
        Guid userId,
        Guid addressId, 
        decimal totalPrice,
        Guid id = new Guid())
    {
        Id = id;
        UserId = userId;
        AddressId = addressId;
        TotalPrice = totalPrice; 
        CreatedAt = DateTime.UtcNow;
    }

    public static decimal CalculateTotalPrice(IEnumerable<OrderItem> orderItems)
    {
        decimal totalPrice = 0;

        foreach (var item in orderItems)
        {
            totalPrice += item.Price;
        }

        return totalPrice;
    }
}
