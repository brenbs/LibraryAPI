using LibraryAPI.Dtos;
using LibraryAPI.Dtos.Users;
using LibraryAPI.FiltersDb;

namespace LibraryAPI.Services.Interface
{
    public interface IUserService
    {
        Task<ResultService> CreateAsync(CreateUserDto createUserDto);
        Task<ResultService<ICollection<UserDto>>> GetAsync();
        Task<ResultService<UserDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(UserDto userDto);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<List<UserDto>>> GetPagedAsync(FilterDb request);
        Task<ResultService<List<UserDash>>> Dash();
    }
}
