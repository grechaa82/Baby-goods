namespace Baby_goods.Common.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetById(string id);
        Task<List<Product>> GetByCategory(string category);
        Task<List<Product>> GetByPriceRange(string priceRange);
        Task<List<Product>> GetByFilter(string? category, string? price);
    }
}
