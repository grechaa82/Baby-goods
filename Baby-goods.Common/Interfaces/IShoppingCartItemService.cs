using Baby_goods.Common.Models;

namespace Baby_goods.Common.Interfaces
{
    public interface IShoppingCartItemService
    {
        Task<List<ShoppingCartItem>> Get(string userId);
        Task<int> GetNumberOfProducts(string userId);
        Task<decimal> GetCost(string userId);
        Task SetQuantity(string shoppingCartItemId, int quantity);
        Task<bool> Create(string productId, string userId);
        Task<bool> Delete(string shoppingCartItemId);
    }
}
