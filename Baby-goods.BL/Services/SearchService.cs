using Baby_goods.Common.Interfaces;

namespace Baby_goods.BL.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository _searchRepository;

        public SearchService(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        public async Task<List<Product>> GetAllByQueryAsync(string query)
        {
            var products = Product.IsArticle(query)
                ? await _searchRepository.GetAllByArticle(query)
                : await _searchRepository.GetAllByTitle(query);

            return products;
        }
    }
}
