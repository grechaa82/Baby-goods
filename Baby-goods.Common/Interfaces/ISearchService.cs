namespace Baby_goods.Common.Interfaces
{
    public interface ISearchService
    {
        Task<List<Product>> GetAllByQueryAsync(string query);
    }
}
