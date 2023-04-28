using Baby_goods.Common.Interfaces.Repositories;

namespace Baby_goods.DAL.Memory
{
    public class AddressRepository : IAddressRepository
    {
        public async Task<Address> Get(Guid id)
        {
            var address = FakeData.address.FirstOrDefault(a => a.Id == id);

            return address;
        }

        public async Task<List<Address>> GetByUserId(Guid userId)
        {
            var addresses = FakeData.address.Where(a => a.User.Id == userId).ToList();

            return addresses;
        }

        public async Task Create(Address address)
        {
            FakeData.address.Add(address);
        }

        public async Task Update(Address address)
        {
            var index = FakeData.address.FindIndex(a => a.Id == address.Id);
            if (index != -1)
            {
                FakeData.address[index] = address;
            }
        }

        public async Task Delete(Guid id)
        {
            var index = FakeData.address.FindIndex(a => a.Id == id);
            if (index != -1)
            {
                FakeData.address.RemoveAt(index);
            }
        }
    }
}
