namespace Baby_goods.Common.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
        Task CreateOrderItem(OrderItem orderItem);
    }
}
