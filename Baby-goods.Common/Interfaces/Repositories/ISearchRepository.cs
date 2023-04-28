namespace Baby_goods.Common.Interfaces.Repositories
{
    public interface ISearchRepository
    {
        Task<List<Product>> GetAllByArticle(string query);
        Task<List<Product>> GetAllByTitle(string query);
    }
}
