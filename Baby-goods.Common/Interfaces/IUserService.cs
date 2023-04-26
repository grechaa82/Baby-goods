namespace Baby_goods.Common.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByEmail(string email);
        Task Create(User user);
    }
}
