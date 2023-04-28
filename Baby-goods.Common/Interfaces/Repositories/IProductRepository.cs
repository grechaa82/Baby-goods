namespace Baby_goods.Common.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(Guid id);
        Task<Product> GetByArticle(string article);
        Task<List<Product>> GetByFilter(string? category, int[]? prices);
    }
}
