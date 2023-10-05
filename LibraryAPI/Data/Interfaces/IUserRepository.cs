using LibraryAPI.Models;

namespace LibraryAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        void Add<T>(T enity)where T:class;
        void Update<T>(T enity) where T : class;
        void Delete<T>(T enity) where T : class;
        bool SaveChanges();

        User[] GetAllUsers();
        User[] GetUsersById(int userId);
    }
}
