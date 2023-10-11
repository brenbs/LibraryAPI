using LibraryAPI.Models;

namespace LibraryAPI.Data.Interfaces
{
    public interface IPublisherRepository
    {
        void Add<T>(T enity) where T : class;
        void Update<T>(T enity) where T : class;
        void Delete<T>(T enity) where T : class;
        bool SaveChanges();

        Publisher[] GetAllPublishers();
        Publisher GetPublishersById(int publisherId);
    }
}
