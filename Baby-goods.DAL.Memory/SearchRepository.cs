using Baby_goods.Common.Interfaces;

namespace Baby_goods.DAL.Memory
{
    public class SearchRepository : ISearchRepository
    {
        HomeRepository HomeRepository { get; set; }

        public async Task<List<Product>> GetAllByArticle(string query)
        {
            if (Product.TryFormatArticle(query, out string formattedArticle))
            {
                var result = HomeRepository._products.Where(p => p.Article ==  formattedArticle).ToList();

                return result;
            }

            return new List<Product> { };
        }

        public async Task<List<Product>> GetAllByTitle(string query)
        {
            var result = HomeRepository._products.Where(p => p.Title.Contains(query, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return result;
        }
    }
}
