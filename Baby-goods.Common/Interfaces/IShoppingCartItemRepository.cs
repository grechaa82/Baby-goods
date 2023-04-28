using Baby_goods.Common.Models;

namespace Baby_goods.Common.Interfaces
{
    public interface IShoppingCartItemRepository
    {
        Task<List<ShoppingCartItem>> GetShoppingCartItemsByUserId(string userId);
        Task<ShoppingCartItem> GetShoppingCartItemById(string userId);
        Task<bool> Delete(string shoppingCartItemId);
        Task<bool> Create(ShoppingCartItem shoppingCartItem);
    }
}
