using Baby_goods.Common.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Baby_goods.DAL.PostgreSQL.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _context;

        public HomeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Get(int pageIndex, int pageSize)
        {
            var result = new List<Product>();

            var items = await _context.Product
                .AsNoTracking()
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .Include(c => c.Category)
                .ToListAsync();

            foreach(var item in items)
            {
                var category = new Category(
                    item.Category.Name, 
                    item.Category.Id, 
                    item.Category.ParentId);

                result.Add(new Product(
                    category, 
                    item.Title, 
                    item.Summary, 
                    item.ImageUrl, 
                    item.Price, 
                    item.Id, 
                    item.Article));
            }

            return result;
        }
    }
}
