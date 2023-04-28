using Baby_goods.Common.Interfaces.Repositories;
using Baby_goods.Common.Models;

namespace Baby_goods.DAL.Memory
{
    public class ShoppingCartItemRepository : IShoppingCartItemRepository
    {
        public async Task<List<ShoppingCartItem>> GetShoppingCartItemsByUserId(string userId)
        {
            var result = FakeData.shoppingCartItem.Where(s => s.UserId == Guid.Parse(userId)).ToList();

            return result;
        }
        
        public async Task<ShoppingCartItem> GetShoppingCartItemById(string userId)
        {
            var result = FakeData.shoppingCartItem.FirstOrDefault(s => s.Id == Guid.Parse(userId));

            return result;
        }
        
        public async Task<bool> Create(ShoppingCartItem shoppingCartItem)
        {
            try
            {
                FakeData.shoppingCartItem.Add(shoppingCartItem);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Delete(string shoppingCartItemId)
        {
            var shoppingCartItem = FakeData.shoppingCartItem.First(s => s.Id == Guid.Parse(shoppingCartItemId));

            return FakeData.shoppingCartItem.Remove(shoppingCartItem);
        }

    }
}
