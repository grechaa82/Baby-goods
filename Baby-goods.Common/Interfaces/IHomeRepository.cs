namespace Baby_goods.Common.Interfaces
{
    public interface IHomeRepository
    {
        Task<List<Product>> Get(int pageIndex, int pageSize);
    }
}
