namespace Baby_goods.Common.Interfaces
{
    public interface IAddressService
    {
        Task<Address> Get(Guid id);
        Task<List<Address>> GetByUserId(Guid userId);
        Task Create(Guid userId,
            string city,
            string country,
            string addressLine1,
            string addressLine2,
            string addressLine3,
            string addressLine4);
        Task UpdateCity(Guid id, string city);
        Task UpdateCountry(Guid id, string country);
        Task UpdateAddressLines(Guid id, string addressLine1, string addressLine2, string addressLine3, string addressLine4);
        Task Delete(Guid id);
    }
}
