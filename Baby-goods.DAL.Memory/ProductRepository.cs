using Baby_goods.Common.Interfaces;

namespace Baby_goods.DAL.Memory
{
    public class ProductRepository : IProductRepository
    {
        public async Task<Product> GetById(string id)
        {
            var result = FakeData.product.FirstOrDefault(p => p.Id == Guid.Parse(id));

            return result;
        }

        public async Task<List<Product>> GetByCategory(string category)
        {
            var result = FakeData.product.Where(p => p.Category.Name == category).ToList();
            
            return result;
        }

        public async Task<List<Product>> GetByPriceRange(int[] prices)
        {
            var result = FakeData.product.Where(p => p.Price >= prices[0] && p.Price <= prices[1]).ToList();

            return result;
        }

        public async Task<List<Product>> GetProducts()
        {
            var result = FakeData.product.ToList();

            return result;
        }
    }
}
