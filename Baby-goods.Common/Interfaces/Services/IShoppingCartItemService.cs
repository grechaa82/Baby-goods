using Baby_goods.Common.Models;

namespace Baby_goods.Common.Interfaces.Services
{
    public interface IShoppingCartItemService
    {
        Task<List<ShoppingCartItem>> Get(Guid userId);
        Task<int> GetNumberOfProducts(Guid userId);
        Task<decimal> GetCost(Guid userId);
        Task SetQuantity(Guid shoppingCartItemId, int quantity);
        Task<bool> Create(Guid productId, Guid userId);
        Task<bool> Delete(Guid shoppingCartItemId);
    }
}
