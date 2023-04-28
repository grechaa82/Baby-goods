namespace Baby_goods.Common.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> Get();
        Task<Category> GetById(Guid categoryId);
        Task<List<Category>> GetSubCategories(Guid categoryId);
    }
}
