namespace Baby_goods.Common.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> Get(Guid id);
        Task<List<Address>> GetByUserId(Guid userId);
        Task Create(Address address);
        Task Update(Address address);
        Task Delete(Guid id);
    }
}
