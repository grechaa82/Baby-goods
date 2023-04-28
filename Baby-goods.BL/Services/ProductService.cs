using Baby_goods.Common.Interfaces.Repositories;
using Baby_goods.Common.Interfaces.Services;

namespace Baby_goods.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<Product> GetByArticle(string article)
        {
            return await _productRepository.GetByArticle(article);
        }

        public async Task<List<Product>> GetByFilter(string? category, string? price)
        {
            int[] prices;
            List<Product> products = new();

            try
            {
                prices = TryParsePricesByPriceRange(price);
            }
            catch (FormatException)
            {
                throw new FormatException ($"'{nameof(price)}' сould not convert to a number.");
            }

            products = await _productRepository.GetByFilter(category, prices);

            return products;
        }

        private int[] TryParsePricesByPriceRange(string price)
        {
            //TODO: Вылетает NullReferenceException, если не передались значение priceRange
            string[] parts = price.Split('-');
            var firstPrice = int.Parse(parts[0]);
            var secondPrice = int.Parse(parts[1]);

            return new int[] { firstPrice, secondPrice };
        }
    }
}
