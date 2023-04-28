using Baby_goods.Common.Interfaces.Repositories;

namespace Baby_goods.DAL.Memory
{
    public class ProductRepository : IProductRepository
    {
        public async Task<Product> GetById(string id)
        {
            var result = FakeData.product.FirstOrDefault(p => p.Id == Guid.Parse(id));

            return result;
        }

        public async Task<Product> GetByArticle(string article)
        {
            var result = FakeData.product.FirstOrDefault(p => p.Article == article);

            if (result == null)
            {
                throw new ArgumentNullException($"According to this '{nameof(article)}' the product was not found.");
            }

            return result;
        }

        public async Task<List<Product>> GetByFilter(string? category, int[]? prices)
        {
            var result = FakeData.product.AsQueryable();

            if (category != null && !string.IsNullOrWhiteSpace(category))
            {
                result = result.Where(p => p.Category.Name == category);
            }

            if (prices != null && prices.Any())
            {
                result = result.Where(p => p.Price >= prices[0] && p.Price <= prices[1]);
            }

            return result.ToList();
        }
    }
}
