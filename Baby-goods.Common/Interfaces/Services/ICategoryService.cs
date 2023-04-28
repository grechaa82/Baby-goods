namespace Baby_goods.Common.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> Get();
        Task<Category> Get(string categoryId);
    }
}
