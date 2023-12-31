﻿using LibraryAPI.Data.Interfaces;
using LibraryAPI.FiltersDb;
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

        public async Task<Book> GetSameBook(string Name,int BookId)
        {
            return await _context.Books.Include(b => b.Publisher).FirstOrDefaultAsync(b => b.Name == Name && b.Id == BookId);
        }

        public async Task<List<Book>> GetPublisherAssociate(int publisherId)
        {
            return await _context.Books.Where(b => b.PublisherId == publisherId).ToListAsync();
        }

        public async Task<PagedBaseResponse<Book>> GetPagedAsync(FilterDb request)
        {
            var book = _context.Books.Include(b => b.Publisher).AsQueryable();
            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                var ignore = request.SearchValue.ToLower();
                              book = book.Where(x => x.Name.ToLower()
                              .Contains(request.SearchValue)||
                              x.Author.ToLower().Contains(ignore) ||
                              x.Stock.ToString().Contains(ignore)||
                              x.Release.ToString().Contains(ignore) ||
                              x.PublisherId.ToString().Contains(ignore) ||
                              x.Publisher.Name.ToLower().Contains(ignore) ||
                              x.TotalRental.ToString().Contains(ignore) ||
                              x.Id.ToString().Contains(ignore));
            }
            return await PagedBaseResponseHelper
                .GetResponseAsync<PagedBaseResponse<Book>, Book>(book, request);
        }
    }
}