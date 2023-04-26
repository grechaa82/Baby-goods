using Baby_goods.Common.Interfaces;

namespace Baby_goods.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public async Task Create(User user)
        {
            await _userRepository.Create(user);
        }
    }
}
