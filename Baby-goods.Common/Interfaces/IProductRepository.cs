namespace Baby_goods.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetById(string id);
        Task<Product> GetByArticle(string id);
        Task<List<Product>> GetByFilter(string? category, int[]? prices);
    }
}
