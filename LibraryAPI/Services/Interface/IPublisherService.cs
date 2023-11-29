using LibraryAPI.Dtos;
using LibraryAPI.Dtos.Publishers;
using LibraryAPI.Dtos.Users;
using LibraryAPI.FiltersDb;
using LibraryAPI.Services;

namespace LibraryAPI.Services.Interface
{
    public interface IPublisherService
    {
        Task<ResultService> CreateAsync(CreatePublisherDto createPublisherDto);
        Task<ResultService<ICollection<PublisherDto>>> GetAsync();
        Task<ResultService<PublisherDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(PublisherDto publisherDto);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<List<PublisherDto>>> GetPagedAsync(FilterDb request);
        Task<ResultService<List<PublisherDash>>> Dash();
        Task<ResultService<ICollection<PublisherBookDto>>> SelectPublisher();
    }
}