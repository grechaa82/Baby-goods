namespace Baby_goods.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetById(string id);
        Task<List<Product>> GetByPriceRange(int[] prices);
        Task<List<Product>> GetByCategory(string cagetory);
        Task<List<Product>> GetProducts();
    }
}
