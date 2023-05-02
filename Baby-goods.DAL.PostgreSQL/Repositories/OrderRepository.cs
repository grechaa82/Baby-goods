using Baby_goods.Common.Interfaces.Repositories;
using Baby_goods.DAL.PostgreSQL.Entities;

namespace Baby_goods.DAL.PostgreSQL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrder(Order order)
        {
            var item = new OrderEntity
            {
                Id = order.Id,
                UserId = order.UserId,
                AddressId = order.AddressId,
                TotalPrice = order.TotalPrice,
                CreatedAt = order.CreatedAt
            };

            await _context.Order.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task CreateOrderItem(OrderItem orderItem)
        {
            var item = new OrderItemEntity
            {
                Id = orderItem.Id,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.Product.Id,
                Quantity = orderItem.Quantity,
                Price = orderItem.Price,
                CreatedAt = orderItem.CreatedAt
            };

            await _context.OrderItem.AddAsync(item);
            await _context.SaveChangesAsync();
        }
    }
}
