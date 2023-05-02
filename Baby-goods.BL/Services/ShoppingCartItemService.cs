using Baby_goods.Common.Interfaces.Repositories;
using Baby_goods.Common.Interfaces.Services;
using Baby_goods.Common.Models;

namespace Baby_goods.BL.Services
{
    public class ShoppingCartItemService : IShoppingCartItemService
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        private readonly IProductRepository _productRepository;

        public ShoppingCartItemService(IShoppingCartItemRepository shoppingCartItemRepository, IProductRepository productRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _productRepository = productRepository;
        }

        public async Task<List<ShoppingCartItem>> Get(Guid userId)
        {
            return await _shoppingCartItemRepository.GetShoppingCartItemsByUserId(userId);
        }

        public async Task<int> GetNumberOfProducts(Guid userId)
        {
            var numberOfProducts = 0;
            var shoppingCartItems = await _shoppingCartItemRepository.GetShoppingCartItemsByUserId(userId);

            if (shoppingCartItems == null)
            {
                return numberOfProducts;
            }

            foreach (var item in shoppingCartItems)
            {
                numberOfProducts += item.Quantity;
            }

            return numberOfProducts;
        }

        public async Task<decimal> GetCost(Guid userId)
        {
            var cost = 0m;

            var shoppingCartItems = await _shoppingCartItemRepository.GetShoppingCartItemsByUserId(userId);

            if (shoppingCartItems == null)
            {
                return cost;
            }

            foreach (var item in shoppingCartItems)
            {
                cost += item.Price;
            }

            return cost;
        }

        public async Task SetQuantity(Guid shoppingCartItemId, int quantity)
        {
            var shoppingCartItem = await _shoppingCartItemRepository.GetShoppingCartItemById(shoppingCartItemId);

            shoppingCartItem.SetQuantity(quantity);

            await _shoppingCartItemRepository.Update(shoppingCartItem);
        }

        public async Task<bool> Create(Guid productId, Guid userId)
        {
            var product = await _productRepository.GetById(productId);

            var shoppingCartItem = new ShoppingCartItem(userId, product);

            return await _shoppingCartItemRepository.Create(shoppingCartItem);
        }

        public async Task<bool> Delete(Guid shoppingCartItemId)
        {
            return await _shoppingCartItemRepository.Delete(shoppingCartItemId);
        }
    }
}
