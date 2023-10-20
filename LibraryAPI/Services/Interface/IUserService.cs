using LibraryAPI.Dtos.Users;

namespace LibraryAPI.Services.Interface
{
    public interface IUserService
    {
        Task<ResultService> CreateAsync(CreateUserDto createUserDto);
    }
}
