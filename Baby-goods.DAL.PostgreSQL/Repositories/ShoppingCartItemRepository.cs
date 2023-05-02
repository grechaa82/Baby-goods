using Baby_goods.Common.Interfaces.Repositories;
using Baby_goods.Common.Models;
using Baby_goods.DAL.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Baby_goods.DAL.PostgreSQL.Repositories
{
    public class ShoppingCartItemRepository : IShoppingCartItemRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository _productRepository;

        public ShoppingCartItemRepository(
            ApplicationDbContext context,
            IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public async Task<bool> Create(ShoppingCartItem shoppingCartItem)
        {
            try
            {
                var item = new ShoppingCartItemEntity
                {
                    Id = shoppingCartItem.Id,
                    UserId = shoppingCartItem.UserId,
                    ProductId = shoppingCartItem.Product.Id,
                    Quantity = shoppingCartItem.Quantity,
                    Price = shoppingCartItem.Price
                };

                await _context.ShoppingCartItem.AddAsync(item);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid shoppingCartItemId)
        {
            try
            {
                var item = await _context.ShoppingCartItem
                    .FirstAsync(s => s.Id == shoppingCartItemId);

                _context.ShoppingCartItem.Remove(item);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ShoppingCartItem> GetShoppingCartItemById(Guid id)
        {
            var item = await _context.ShoppingCartItem
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            var product = await _productRepository.GetById(item.ProductId);

            var result = new ShoppingCartItem(
                item.UserId,
                product,
                item.Id,
                item.Quantity);

            return result;
        }

        public async Task<List<ShoppingCartItem>> GetShoppingCartItemsByUserId(Guid userId)
        {
            var result = new List<ShoppingCartItem>();
            var items = await _context.ShoppingCartItem
                .AsNoTracking()
                .Where(s => s.UserId == userId)
                .ToListAsync();

            foreach (var item in items)
            {
                var product = await _productRepository.GetById(item.ProductId);

                result.Add(new ShoppingCartItem(
                    item.UserId,
                    product,
                    item.Id,
                    item.Quantity));
            }

            return result;
        }

        public async Task Update(ShoppingCartItem shoppingCartItem)
        {
            var item = new ShoppingCartItemEntity
            {
                Id = shoppingCartItem.Id,
                UserId = shoppingCartItem.UserId,
                ProductId = shoppingCartItem.Product.Id,
                Quantity = shoppingCartItem.Quantity,
                Price = shoppingCartItem.Price
            };

            _context.ShoppingCartItem.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
