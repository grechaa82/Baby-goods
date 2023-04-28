namespace Baby_goods.Common.Interfaces.Services
{
    public interface IHomeService
    {
        Task<List<Product>> Get(int pageIndex, int pageSize);
    }
}
