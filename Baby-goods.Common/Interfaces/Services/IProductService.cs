namespace Baby_goods.Common.Interfaces.Services
{
    public interface IProductService
    {
        Task<Product> GetById(Guid id);
        Task<Product> GetByArticle(string article);
        Task<List<Product>> GetByFilter(string? category, string? price);
    }
}
