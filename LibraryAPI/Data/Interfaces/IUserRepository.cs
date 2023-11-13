using LibraryAPI.FiltersDb;
using LibraryAPI.Models;

namespace LibraryAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task Update(User user);
        Task Delete(User user);
        Task<ICollection<User>> GetAllusers();
        Task<User> GetuserById(int userId);
        Task<User> GetuserByName(string userName);
        Task<User> GetuserByEmail(string userEmail);
        Task<PagedBaseResponse<User>> GetPagedAsync(FilterDb request);
    }
}
