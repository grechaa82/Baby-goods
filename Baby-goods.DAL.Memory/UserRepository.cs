using Baby_goods.Common.Interfaces;

namespace Baby_goods.DAL.Memory
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetByEmail(string email)
        {
            return FakeData.user.FirstOrDefault(u => u.Email == email);
        }

        public async Task Create(User user)
        {
            FakeData.user.Add(user);
        }
    }
}
