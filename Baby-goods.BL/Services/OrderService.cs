using Baby_goods.Common.Interfaces.Repositories;
using Baby_goods.Common.Interfaces.Services;

namespace Baby_goods.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public OrderService(
            IOrderRepository orderRepository, 
            IUserRepository userRepository, 
            IAddressRepository addressRepository, 
            IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public async Task Create(Guid userId, Guid addressId)
        {
            var user = await _userRepository.GetById(userId);
            var address = await _addressRepository.Get(addressId);
            var shoppingCartItems = await _shoppingCartItemRepository.GetShoppingCartItemsByUserId(userId);

            var totalPrice = 0m;
            foreach (var item in shoppingCartItems)
            {
                totalPrice += item.CalculatePrice(); 
            }

            var order = new Order(user.Id, address.Id, totalPrice);

            var orderItems = new List<OrderItem>();

            foreach (var item in shoppingCartItems)
            {
                var orderItem = new OrderItem(order.Id, item.Product, item.Quantity, item.Price);
                orderItems.Add(orderItem);
                await _orderRepository.CreateOrderItem(orderItem);
            }

            await _orderRepository.CreateOrder(order);
        }
    }
}
