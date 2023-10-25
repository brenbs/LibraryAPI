using LibraryAPI.Data.Interfaces;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryAPI.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Book book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
           
        }
        public async Task Update(Book book)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Book book)
        {
            _context.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Book>> GetAllBooks()
        {
           return await _context.Books.Include(b => b.Publisher).ToListAsync();
        }

        public async Task<Book> GetBooksById(int BookId)
        {
            return await _context.Books.Include(b => b.Publisher).FirstOrDefaultAsync(b => b.Id == BookId);

        }

        public async Task<Book> GetBooksByName(string Name)
        {
            return await _context.Books.Include(b => b.Publisher).FirstOrDefaultAsync(b => b.Name == Name);
        }
    }
}
