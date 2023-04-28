namespace Baby_goods.Common.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetByEmail(string email);
        Task Create(User user);
        Task<User> GetById(Guid id);
        Task UpdateUsername(Guid id, string username);
        Task UpdatePassword(Guid id, string password);
        Task UpdateFirstNameAndLastName(Guid id, string firstName, string lastName);
        Task UpdatePhone(Guid id, string phone);
    }
}
