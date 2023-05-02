using Baby_goods.Common.Interfaces.Repositories;
using Baby_goods.Common.Models;

namespace Baby_goods.DAL.Memory
{
    public class ShoppingCartItemRepository : IShoppingCartItemRepository
    {
        public async Task<List<ShoppingCartItem>> GetShoppingCartItemsByUserId(Guid userId)
        {
            var result = FakeData.shoppingCartItem.Where(s => s.UserId == userId).ToList();

            return result;
        }
        
        public async Task<ShoppingCartItem> GetShoppingCartItemById(Guid userId)
        {
            var result = FakeData.shoppingCartItem.FirstOrDefault(s => s.Id == userId);

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

        public async Task<bool> Delete(Guid shoppingCartItemId)
        {
            var shoppingCartItem = FakeData.shoppingCartItem.First(s => s.Id == shoppingCartItemId);

            return FakeData.shoppingCartItem.Remove(shoppingCartItem);
        }

        public Task Update(ShoppingCartItem shoppingCartItem)
        {
            throw new NotImplementedException();
        }
    }
}
