using LibraryAPI.FiltersDb;
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
        Task<Book> GetBooksByName(string Name);
        Task<Book> GetSameBook(string Name,int BookId);
        Task<List<Book>> GetPublisherAssociate(int publisherId);
        Task<PagedBaseResponse<Book>> GetPagedAsync(FilterDb request);
    }
}