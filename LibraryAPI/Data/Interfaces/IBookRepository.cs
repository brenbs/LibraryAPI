using LibraryAPI.Models;

namespace LibraryAPI.Data.Interfaces
{
    public interface IBookRepository
    {
        void Add<T>(T enity) where T : class;
        void Update<T>(T enity) where T : class;
        void Delete<T>(T enity) where T : class;
        bool SaveChanges();

        Book[] GetAllBooks(bool includePublishers = false); 
        Book GetBooksById(int BookId, bool includePublishers = false);
    }
}
