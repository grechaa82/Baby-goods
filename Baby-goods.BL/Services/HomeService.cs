using Baby_goods.Common.Interfaces.Repositories;
using Baby_goods.Common.Interfaces.Services;

namespace Baby_goods.BL.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<List<Product>> Get(int pageIndex, int pageSize)
        {
            return await _homeRepository.Get(pageIndex, pageSize);
        }
    }
}
