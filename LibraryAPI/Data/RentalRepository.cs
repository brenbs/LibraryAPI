using LibraryAPI.Data.Interfaces;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class RentalRepository : IRentalRepository
    {
        private readonly DataContext _context;

        public RentalRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task<Rental> Add(Rental rental)
        {
            _context.Add(rental);
            await _context.SaveChangesAsync();
            return rental;
        }

        public async Task Update(Rental rental)
        {
            _context.Update(rental);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Rental rental)
        {
            _context.Remove(rental);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Rental>> GetAllRentals()
        {
            return await _context.Rentals.Include(r => r.User).Include(r => r.Book).ToListAsync();
        }

        public async Task<Rental> GetRentalsById(int rentalId)
        {
            return await _context.Rentals.Include(r => r.User).Include(r => r.Book).Where(r=> r.Id==rentalId).FirstOrDefaultAsync();
        }
        public async Task<Rental> GetBookUser(int bookId,int userId)
        {
            return await _context.Rentals.Where(r=> r.BookId == bookId && r.UserId== userId).FirstOrDefaultAsync();
        }
        public async Task<Rental> GetRentalUser(int userId)
        {
            return await _context.Rentals.Where(r => r.UserId == userId).FirstOrDefaultAsync();
        }
        public async Task<Rental> GetRentalBook(int bookId)
        {
            return await _context.Rentals.Where(r => r.BookId == bookId).FirstOrDefaultAsync();
        }
    }
}
