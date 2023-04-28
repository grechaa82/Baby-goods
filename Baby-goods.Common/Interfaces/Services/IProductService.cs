namespace Baby_goods.Common.Interfaces.Services
{
    public interface IProductService
    {
        Task<Product> GetById(string id);
        Task<Product> GetByArticle(string id);
        Task<List<Product>> GetByFilter(string? category, string? price);
    }
}
