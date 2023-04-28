using Baby_goods.Common.Interfaces.Repositories;

namespace Baby_goods.DAL.Memory
{
    public class HomeRepository : IHomeRepository
    {
        public async Task<List<Product>> Get(int pageIndex, int pageSize)
        {
            var result = FakeData.product
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();

            return result;
        }
    }
}