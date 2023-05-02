using Baby_goods.Common.Interfaces.Repositories;
using Baby_goods.DAL.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Baby_goods.DAL.PostgreSQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            var role = await _context.Role
                .AsNoTracking()
                .FirstAsync(r => r.Title == user.Role.ToString());

            var item = new UserEntity
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                RoleId = role.Id,
                CreatedAt = user.CreatedAt,
                ModifiedAt = user.ModifiedAt
            };

            await _context.User.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var item = await _context.User
                .AsNoTracking()
                .Include(r => r.Role)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (item == null)
            {
                return null;
            }

            var result = new User(
                item.Username,
                item.Email,
                item.Password,
                item.FirstName,
                item.LastName,
                item.Phone,
                (Role)Enum.Parse(typeof(Role), item.Role.Title),
                item.Id);

            return result;
        }

        public async Task<User> GetById(Guid id)
        {
            var item = await _context.User
                .AsNoTracking()
                .Include(r => r.Role)
                .FirstAsync(u => u.Id == id);

            var result = new User(
                item.Username,
                item.Email,
                item.Password,
                item.FirstName,
                item.LastName,
                item.Phone,
                (Role)Enum.Parse(typeof(Role), item.Role.Title),
                item.Id);

            return result;
        }

        public async Task Update(User user)
        {
            var roleItem = await _context.Role
                .AsNoTracking()
                .FirstAsync(r => r.Title == user.Role.ToString());

            var item = new UserEntity 
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                RoleId = roleItem.Id,
                CreatedAt = user.CreatedAt,
                ModifiedAt = user.ModifiedAt,
            };

            _context.User.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
