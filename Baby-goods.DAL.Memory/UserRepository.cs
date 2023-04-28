using Baby_goods.Common.Interfaces.Repositories;

namespace Baby_goods.DAL.Memory
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetById(Guid id)
        {
            return FakeData.user.FirstOrDefault(u => u.Id == id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return FakeData.user.FirstOrDefault(u => u.Email == email);
        }

        public async Task Create(User user)
        {
            FakeData.user.Add(user);
        }

        public async Task Update(User user)
        {
            var index = FakeData.user.FindIndex(u => u.Id == user.Id);
            if (index != -1)
            {
                FakeData.user[index] = user;
            }
        }
    }
}
