using Baby_goods.Common.Interfaces.Repositories;
using Baby_goods.DAL.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Baby_goods.DAL.PostgreSQL.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Address address)
        {
            var item = new AddressEntity()
            {
                Id = address.Id,
                UserId = address.User.Id,
                City = address.City,
                Country = address.Country,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                AddressLine3 = address.AddressLine3,
                AddressLine4 = address.AddressLine4
            };

            await _context.Address.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var item = await _context.Address.FirstOrDefaultAsync(a => a.Id == id);

            if (item != null)
            {
                _context.Address.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Address> Get(Guid id)
        {
            var item = await _context.Address
                .AsNoTracking()
                .Include(u => u.User)
                .Include(r => r.User.Role)
                .FirstOrDefaultAsync(a => a.Id == id);

            var role = (Role)Enum.Parse(typeof(Role), item.User.Role.Title);

            var user = new User(
                item.User.Username,
                item.User.Email,
                item.User.Password,
                item.User.FirstName,
                item.User.LastName,
                item.User.Phone,
                role,
                item.User.Id);

            var result = new Address(
                user,
                item.City,
                item.Country,
                item.AddressLine1,
                item.AddressLine2,
                item.AddressLine3,
                item.AddressLine4,
                item.Id);

            return result;
        }

        public async Task<List<Address>> GetByUserId(Guid userId)
        {
            var result = new List<Address>();

            var items = await _context.Address
               .AsNoTracking()
               .Include(u => u.User)
               .Include(r => r.User.Role)
               .Where(a => a.UserId == userId)
               .ToListAsync();

            var role = (Role)Enum.Parse(typeof(Role), items[0].User.Role.Title);

            var user = new User(
                items[0].User.Username,
                items[0].User.Email,
                items[0].User.Password,
                items[0].User.FirstName,
                items[0].User.LastName,
                items[0].User.Phone,
                role,
                items[0].User.Id);

            foreach(var item in items)
            {
                result.Add(new Address(
                user,
                item.City,
                item.Country,
                item.AddressLine1,
                item.AddressLine2,
                item.AddressLine3,
                item.AddressLine4,
                item.Id));
            }

            return result;
        }

        public async Task Update(Address address)
        {
            var item = new AddressEntity()
            {
                Id = address.Id,
                UserId = address.User.Id,
                City = address.City,
                Country = address.Country,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                AddressLine3 = address.AddressLine3,
                AddressLine4 = address.AddressLine4
            };

            _context.Address.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
