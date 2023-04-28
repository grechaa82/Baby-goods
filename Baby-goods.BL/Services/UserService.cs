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

        public async Task<User> GetById(Guid id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public async Task Create(User user)
        {
            await _userRepository.Create(user);
        }

        public async Task UpdateUsername(Guid id, string username)
        {
            var user = await _userRepository.GetById(id);

            user.SetUsername(username);

            await _userRepository.Update(user);
        }

        public async Task UpdatePassword(Guid id, string password)
        {
            var user = await _userRepository.GetById(id);

            user.SetPassword(password);

            await _userRepository.Update(user);
        }

        public async Task UpdateFirstNameAndLastName(Guid id, string firstName, string lastName)
        {
            var user = await _userRepository.GetById(id);

            user.SetFirstNameAndLastName(firstName, lastName);

            await _userRepository.Update(user);
        }

        public async Task UpdatePhone(Guid id, string phone)
        {
            var user = await _userRepository.GetById(id);

            user.SetPhone(phone);

            await _userRepository.Update(user);
        }
    }
}
