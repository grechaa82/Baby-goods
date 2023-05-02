using Baby_goods.Common.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Baby_goods.DAL.PostgreSQL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByArticle(string article)
        {
            var item = await _context.Product
                .AsNoTracking()
                .Include(c => c.Category)
                .FirstOrDefaultAsync(p => p.Article == article);

            if (item == null)
            {
                throw new ArgumentNullException($"According to this '{nameof(article)}' the product was not found.");
            }

            var category = new Category(
                item.Category.Name,
                item.Category.Id,
                item.Category.ParentId);

            var result = new Product(
                category,
                item.Title,
                item.Summary,
                item.ImageUrl,
                item.Price,
                item.Id,
                item.Article);

            return result;
        }

        public async Task<List<Product>> GetByFilter(string? category, int[]? prices)
        {
            var result = new List<Product>();
            var items = _context.Product.AsQueryable();

            if (category != null && !string.IsNullOrWhiteSpace(category))
            {
                items = items.Where(c => c.Category.Name == category);
            }

            if (prices != null && prices.Any())
            {
                items = items.Where(p => p.Price >= prices[0] && p.Price <= prices[1]);
            }

            await items.Include(c => c.Category).ToArrayAsync();

            foreach (var item in items)
            {
                var resultCategory = new Category(
                item.Category.Name,
                item.Category.Id,
                item.Category.ParentId);

                result.Add(new Product(
                    resultCategory,
                    item.Title,
                    item.Summary,
                    item.ImageUrl,
                    item.Price,
                    item.Id,
                    item.Article));
            }

            return result;
        }

        public async Task<Product> GetById(Guid id)
        {
            var item = await _context.Product
                .AsNoTracking()
                .Include(c => c.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            var category = new Category(
                item.Category.Name,
                item.Category.Id,
                item.Category.ParentId);

            var result = new Product(
                category,
                item.Title,
                item.Summary,
                item.ImageUrl,
                item.Price,
                item.Id,
                item.Article);

            return result;
        }
    }
}
