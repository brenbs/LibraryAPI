using LibraryAPI.Dtos.Users;

namespace LibraryAPI.Services.Interface
{
    public interface IUserService
    {
        Task<ResultService> CreateAsync(CreateUserDto createUserDto);
        Task<ResultService<ICollection<UserDto>>> GetAsync();
        Task<ResultService<UserDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(UserDto userDto);
        Task<ResultService> DeleteAsync(int id);
    }
}
