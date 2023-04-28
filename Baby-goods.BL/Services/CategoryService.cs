using Baby_goods.Common.Interfaces.Repositories;
using Baby_goods.Common.Interfaces.Services;

namespace Baby_goods.BL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Get()
        {
            return await _categoryRepository.Get();
        }

        public async Task<Category> Get(string categoryId)
        {
            var categoty = await _categoryRepository.GetById(categoryId);
            var subCategoties = await _categoryRepository.GetSubCategories(categoryId);

            categoty.AddCategories(subCategoties);

            return categoty;
        }
    }
}
