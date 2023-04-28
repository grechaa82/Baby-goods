namespace Baby_goods.Common.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
        Task CreateOrderItem(OrderItem orderItem);
    }
}
