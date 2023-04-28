namespace Baby_goods.Common.Interfaces.Repositories
{
    public interface IHomeRepository
    {
        Task<List<Product>> Get(int pageIndex, int pageSize);
    }
}
