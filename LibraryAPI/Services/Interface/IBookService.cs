using LibraryAPI.Data;
using LibraryAPI.Dtos;
using LibraryAPI.Dtos.Books;
using LibraryAPI.Dtos.Users;
using LibraryAPI.FiltersDb;
using LibraryAPI.Models;

namespace LibraryAPI.Services.Interface
{
    public interface IBookService
    {
        Task<ResultService> CreateAsync(CreateBookDto createBookDto);
        Task<ResultService<ICollection<BookDto>>> GetAsync();
        Task<ResultService<BookDto>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(UpdateBookDto updatebookDto);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<List<BookDto>>> GetPagedAsync(FilterDb request);
        Task<ResultService<List<BookDash>>> Dash();
    }
}
