using Baby_goods.Common.Interfaces.Repositories;

namespace Baby_goods.DAL.Memory
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<List<Category>> Get()
        {
            var result = FakeData.category.Where(c => c.ParentId == null).ToList();

            return result;
        }

        public async Task<Category> GetById(Guid categoryId)
        {
            var result = FakeData.category.FirstOrDefault(c => c.Id == categoryId);

            return result;
        }

        public async Task<List<Category>> GetSubCategories(Guid categoryId)
        {
            var subCategories = FakeData.category.Where(c => c.ParentId == categoryId).ToList();

            return subCategories;
        }
    }
}
