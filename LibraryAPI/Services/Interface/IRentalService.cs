using LibraryAPI.Dtos.Publishers;
using LibraryAPI.Dtos;
using LibraryAPI.Dtos.Rentals;
using LibraryAPI.FiltersDb;

namespace LibraryAPI.Services.Interface
{
    public interface IRentalService
    {
        Task<ResultService> CreateAsync(CreateRentalDto createRentalDto);
        Task<ResultService<ICollection<RentalDto>>> GetAsync();
        Task<ResultService<RentalDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(UpdateRentalDto updateRentalDto);
        Task<ResultService<PagedBaseResponseDto<RentalDto>>> GetPagedAsync(FilterDb request);
    }
}
