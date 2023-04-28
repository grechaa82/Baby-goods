namespace Baby_goods.Common.Interfaces.Services
{
    public interface ISearchService
    {
        Task<List<Product>> GetAllByQueryAsync(string query);
    }
}
