using Baby_goods.Common.Interfaces;

namespace Baby_goods.DAL.Memory
{
    public class OrderRepository : IOrderRepository
    {
        public async Task CreateOrder(Order order)
        {
            FakeData.order.Add(order);
        }

        public async Task CreateOrderItem(OrderItem orderItem)
        {
            FakeData.orderItem.Add(orderItem);
        }
    }
}
