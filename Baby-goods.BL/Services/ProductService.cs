using Baby_goods.Common.Interfaces;

namespace Baby_goods.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetById(string id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<List<Product>> GetByCategory(string category)
        {
            return await _productRepository.GetByCategory(category);
        }

        public async Task<List<Product>> GetByPriceRange(string priceRange)
        {
            var prices = GetPricesByPriceRange(priceRange);
            return await _productRepository.GetByPriceRange(prices);
        }

        public async Task<List<Product>> GetByFilter(string? category, string? price)
        {
            var products = await _productRepository.GetProducts();

            if (category != null && !string.IsNullOrWhiteSpace(category))
            {
                products = products.Where(p => p.Category.Name == category).ToList();
            }

            if (price != null && price.Any())
            {
                var prices = GetPricesByPriceRange(price);

                products = products.Where(p => p.Price >= prices[0] && p.Price <= prices[1]).ToList();
            }

            return products.ToList();
        }

        private int[] GetPricesByPriceRange(string price)
        {
            string[] parts = price.Split('-');
            var firstPrice = int.Parse(parts[0]);
            var secondPrice = int.Parse(parts[1]);

            return new int[] { firstPrice, secondPrice };
        }
    }
}
