using Baby_goods.Common.Models;

namespace Baby_goods.Common.Interfaces.Repositories
{
    public interface IShoppingCartItemRepository
    {
        Task<List<ShoppingCartItem>> GetShoppingCartItemsByUserId(Guid userId);
        Task<ShoppingCartItem> GetShoppingCartItemById(Guid userId);
        Task<bool> Delete(Guid shoppingCartItemId);
        Task<bool> Create(ShoppingCartItem shoppingCartItem);
    }
}
