using Baby_goods.Common.Interfaces;

namespace Baby_goods.BL.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;

        public AddressService(IAddressRepository addressRepository, IUserRepository userRepository)
        {
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }

        public async Task<Address> Get(Guid id)
        {
            return await _addressRepository.Get(id);
        }

        public async Task<List<Address>> GetByUserId(Guid userId)
        {
            return await _addressRepository.GetByUserId(userId);
        }

        public async Task Create(Guid userId,
            string city,
            string country,
            string addressLine1,
            string addressLine2,
            string addressLine3,
            string addressLine4)
        {
            var user = await _userRepository.GetById(userId);

            var adderss = new Address(
                user,
                city,
                country,
                addressLine1,
                addressLine2,
                addressLine3,
                addressLine4);

            await _addressRepository.Create(adderss);
        }

        public async Task UpdateCity(Guid id, string city)
        {
            var address = await _addressRepository.Get(id);

            address.SetCity(city);

            await _addressRepository.Update(address);
        }

        public async Task UpdateCountry(Guid id, string country)
        {
            var address = await _addressRepository.Get(id);

            address.SetCountry(country);

            await _addressRepository.Update(address);
        }
        public async Task UpdateAddressLines(
            Guid id, 
            string addressLine1, 
            string addressLine2, 
            string addressLine3, 
            string addressLine4)
        {
            var address = await _addressRepository.Get(id);

            address.SetAddressLines(
                addressLine1,
                addressLine2,
                addressLine3,
                addressLine4);

            await _addressRepository.Update(address);
        }

        public async Task Delete(Guid id)
        {
            await _addressRepository.Delete(id);
        }
    }
}
