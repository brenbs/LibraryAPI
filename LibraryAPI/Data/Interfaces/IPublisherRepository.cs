using LibraryAPI.Models;

namespace LibraryAPI.Data.Interfaces
{
    public interface IPublisherRepository
    {
        Task<Publisher> Add(Publisher publisher);
        Task Update(Publisher publisher);
        Task Delete(Publisher publisher);

        Task<ICollection<Publisher>> GetAllPublishers();
        Task <Publisher> GetPublisherById(int publisherId);

        Task<Publisher> GetPublisherByName(string publisherName);

    }
}
