using Baby_goods.Common.Interfaces;
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

        public async Task<List<ShoppingCartItem>> Get(string userId)
        {
            return await _shoppingCartItemRepository.GetShoppingCartItemsByUserId(userId);
        }

        public async Task<int> GetNumberOfProducts(string userId)
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

        public async Task<decimal> GetCost(string userId)
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

        public async Task SetQuantity(string shoppingCartItemId, int quantity)
        {
            var shoppingCartItem = await _shoppingCartItemRepository.GetShoppingCartItemById(shoppingCartItemId);

            shoppingCartItem.SetQuantity(quantity);

            if (!await _shoppingCartItemRepository.Create(shoppingCartItem))
            {
                throw new Exception("Something went wrong");
            }

            if (!await _shoppingCartItemRepository.Delete(shoppingCartItemId))
            {
                throw new Exception("Something went wrong");
            }
        }

        public async Task<bool> Create(string productId, string userId)
        {
            var product = await _productRepository.GetById(productId);

            var shoppingCartItem = new ShoppingCartItem(Guid.Parse(userId), product);

            return await _shoppingCartItemRepository.Create(shoppingCartItem);
        }

        public async Task<bool> Delete(string shoppingCartItemId)
        {
            return await _shoppingCartItemRepository.Delete(shoppingCartItemId);
        }
    }
}
