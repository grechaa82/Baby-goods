namespace Baby_goods.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task Create(User user);
    }
}
