using LibraryAPI.Dtos.Publishers;

namespace LibraryAPI.Services.Interface
{
    public interface IPublisherService
    {
        Task<ResultService> CreateAsync(CreatePublisherDto createPublisherDto);
        Task<ResultService<ICollection<PublisherDto>>> GetAsync();
        Task<ResultService<PublisherDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(PublisherDto publisherDto);
        Task<ResultService> DeleteAsync(int id);
    }
}
