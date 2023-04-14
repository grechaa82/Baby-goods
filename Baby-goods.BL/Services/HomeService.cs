﻿using Baby_goods.Common.Interfaces;

namespace Baby_goods.BL.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<List<Product>> Get()
        {
            return await _homeRepository.Get();
        }
    }
}
