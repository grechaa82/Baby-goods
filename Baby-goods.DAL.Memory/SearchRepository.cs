using Baby_goods.Common.Interfaces;

namespace Baby_goods.DAL.Memory
{
    public class SearchRepository : ISearchRepository
    {
        public async Task<List<Product>> GetAllByArticle(string query)
        {
            if (Product.TryFormatArticle(query, out string formattedArticle))
            {
                var result = FakeData.product.Where(p => p.Article ==  formattedArticle).ToList();

                return result;
            }

            return new List<Product> { };
        }

        public async Task<List<Product>> GetAllByTitle(string query)
        {
            var result = FakeData.product.Where(p => p.Title.Contains(query, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return result;
        }
    }
}
