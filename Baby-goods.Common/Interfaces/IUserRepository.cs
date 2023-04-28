namespace Baby_goods.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid id);
        Task<User> GetByEmail(string email);
        Task Create(User user);
        Task Update(User user);
    }
}
