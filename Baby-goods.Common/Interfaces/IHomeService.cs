namespace Baby_goods.Common.Interfaces
{
    public interface IHomeService
    {
        Task<List<Product>> Get(int pageIndex, int pageSize);
    }
}
