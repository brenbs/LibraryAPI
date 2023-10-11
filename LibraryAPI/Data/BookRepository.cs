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

        public void Add<T>(T enity) where T : class
        {
            _context.Add(enity);
        }

        public void Update<T>(T enity) where T : class
        {
            _context.Update(enity);
        }

        public void Delete<T>(T enity) where T : class
        {
            _context.Remove(enity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Book[] GetAllBooks(bool includePublishers = false)
        {
            IQueryable<Book> query = _context.Books;

            query = query.AsNoTracking().Include(b => b.Publisher).OrderBy(b => b.Id); //pega os usuarios e ordena por id
            return query.ToArray();
        }

        public Book GetBooksById(int bookId, bool includePublishers = false)
        {
            IQueryable<Book> query = _context.Books;

            query = query.AsNoTracking().Include(b=>b.Publisher).OrderBy(b => b.Id).Where(book => book.Id == bookId);

            return query.FirstOrDefault();
        }
    }
}
