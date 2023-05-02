using Baby_goods.Common.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Baby_goods.DAL.PostgreSQL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> Get()
        {
            var result = new List<Category>();

            var items = await _context.Category
                .AsNoTracking()
                .Where(c => c.ParentId == null)
                .ToListAsync();

            foreach (var item in items)
            {
                result.Add(new Category(
                    item.Name,
                    item.Id,
                    item.ParentId));
            }

            return result;
        }

        public async Task<Category> GetById(Guid categoryId)
        {
            var item = await _context.Category
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            var result = new Category(
                item.Name, 
                item.Id, 
                item.ParentId);

            return result;
        }

        public async Task<List<Category>> GetSubCategories(Guid categoryId)
        {
            var result = new List<Category>();

            var items = await _context.Category
                .AsNoTracking()
                .Where(c => c.ParentId == categoryId)
                .ToListAsync();

            foreach (var item in items)
            {
                result.Add(new Category(
                    item.Name,
                    item.Id,
                    item.ParentId));
            }

            return result;
        }
    }
}
