namespace Baby_goods.Common.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetById(string id);
        Task<Product> GetByArticle(string id);
        Task<List<Product>> GetByFilter(string? category, string? price);
    }
}
