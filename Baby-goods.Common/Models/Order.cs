public class Order
{
    public Guid Id { get; }
    public User User { get; }
    public Address Address { get; }
    public decimal TotalPrice { get; private set; }
    public DateTime CreatedAt { get; }

    public Order( 
        User user, 
        Address address, 
        decimal totalPrice,
        Guid id = new Guid())
    {
        Id = id;
        User= user;
        Address = address;
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
