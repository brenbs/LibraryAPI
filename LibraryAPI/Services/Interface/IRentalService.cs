using LibraryAPI.Dtos.Publishers;
using LibraryAPI.Dtos;
using LibraryAPI.Dtos.Rentals;
using LibraryAPI.FiltersDb;
using LibraryAPI.Dtos.Users;

namespace LibraryAPI.Services.Interface
{
    public interface IRentalService
    {
        Task<ResultService> CreateAsync(CreateRentalDto createRentalDto);
        Task<ResultService<ICollection<RentalDto>>> GetAsync();
        Task<ResultService<RentalDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(UpdateRentalDto updateRentalDto);
        Task<ResultService<List<RentalDto>>> GetPagedAsync(FilterDb request);
        Task<ResultService<List<RentalDash>>> Dash();
    }
}
