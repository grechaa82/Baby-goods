using Baby_goods.Common.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Baby_goods.DAL.PostgreSQL.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly ApplicationDbContext _context;

        public SearchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllByArticle(string query)
        {
            if (Product.TryFormatArticle(query, out string formattedArticle))
            {
                var result = new List<Product>();

                var items = await _context.Product
                    .AsNoTracking()
                    .Where(p => p.Article == formattedArticle)
                    .Include(c => c.Category)
                    .ToListAsync();

                foreach (var item in items)
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

            return new List<Product> { };
        }

        public async Task<List<Product>> GetAllByTitle(string query)
        {
            var result = new List<Product>();

            // !!! System.InvalidOperationException: The expression 'c.Title' is invalid inside an 'Include' operation, since it does not represent a property access: 't => t.MyProperty'. To target navigations declared on derived types, use casting ('t => ((Derived)t).MyProperty') or the 'as' operator ('t => (t as Derived).MyProperty'). Collection navigation access can be filtered by composing Where, OrderBy(Descending), ThenBy(Descending), Skip or Take operations. For more information on including related data, see http://go.microsoft.com/fwlink/?LinkID=746393.
            var items = await _context.Product
                .AsNoTracking()
                .Include(c => c.Category)
                .Where(p => EF.Functions.Like(p.Title, $"{query}%"))
                .ToListAsync();

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
    }
}
