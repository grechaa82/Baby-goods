namespace Baby_goods.Common.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> Get();
        Task<Category> GetById(string categoryId);
        Task<List<Category>> GetSubCategories(string categoryId);
    }
}
