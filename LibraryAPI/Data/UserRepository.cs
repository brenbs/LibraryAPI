using LibraryAPI.Data.Interfaces;
using LibraryAPI.FiltersDb;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<User> Add(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Update(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(User user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAllusers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetuserById(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User> GetuserByName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == userName);
        }

        public async Task<User> GetuserByEmail(string userEmail)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
        }

        public async Task<PagedBaseResponse<User>> GetPagedAsync(FilterDb request)
        {
            var user = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                var ignore = request.SearchValue.ToLower();
                user = user.Where(x => x.Name.ToLower()
                .Contains(request.SearchValue) ||
                x.Email.ToLower().Contains(ignore) ||
                x.Address.ToLower().Contains(ignore) ||
                x.City.ToLower().Contains(ignore) ||
                x.Id.ToString().Contains(ignore));
            }
            return  await PagedBaseResponseHelper
                .GetResponseAsync<PagedBaseResponse<User>, User>(user, request);
        }
    }
}
