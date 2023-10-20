using LibraryAPI.Models;

namespace LibraryAPI.Data.Interfaces
{
    public interface IBookRepository
    {
        Task Add(Book book);    
        Task Update(Book book);
        Task Delete(Book book);

        Task <ICollection<Book>> GetAllBooks(); 
        Task <Book> GetBooksById(int BookId);
    }
}
