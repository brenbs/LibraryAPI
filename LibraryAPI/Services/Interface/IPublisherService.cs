using LibraryAPI.Dtos;
using LibraryAPI.Dtos.Publishers;
using LibraryAPI.FiltersDb;

namespace LibraryAPI.Services.Interface
{
    public interface IPublisherService
    {
        Task<ResultService> CreateAsync(CreatePublisherDto createPublisherDto);
        Task<ResultService<ICollection<PublisherDto>>> GetAsync();
        Task<ResultService<PublisherDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(PublisherDto publisherDto);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<PagedBaseResponseDto<PublisherDto>>> GetPagedAsync(PublisherFilterDb publisherFilterDb);
    }
}
