using LibraryAPI.Dtos.Rentals;

namespace LibraryAPI.Services.Interface
{
    public interface IRentalService
    {
        Task<ResultService> CreateAsync(CreateRentalDto createRentalDto);
        Task<ResultService<ICollection<RentalDto>>> GetAsync();
        Task<ResultService<RentalDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(UpdateRentalDto updateRentalDto);
        Task <ResultService> DeleteAsync(int id);
    }
}
