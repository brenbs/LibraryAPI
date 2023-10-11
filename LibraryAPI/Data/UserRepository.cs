using LibraryAPI.Data.Interfaces;
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

        public void Add<T>(T enity) where T : class
        {
            _context.Add(enity);
        }

        public void Update<T>(T enity) where T : class
        {
            _context.Update(enity);
        }

        public void Delete<T>(T enity) where T : class
        {
            _context.Remove(enity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public User[] GetAllUsers()
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking().OrderBy(u => u.Id); //pega os usuarios e ordena por id
            return query.ToArray();
        }

        public User GetUsersById(int userId)
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking().OrderBy(u => u.Id).Where(user => user.Id == userId);

            return query.FirstOrDefault();
        }
    }
}
