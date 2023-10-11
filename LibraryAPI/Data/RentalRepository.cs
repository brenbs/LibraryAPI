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

        public Rental[] GetAllRentals(bool BookRentalDto = false, bool UserRentalDto = false)
        {
            IQueryable<Rental> query = _context.Rentals;

            query = query.AsNoTracking().Include(b =>b.User).Include(b =>b.Book).OrderBy(r => r.Id); 
            return query.ToArray();
        }

        public Rental GetRentalsById(int rentalId, bool BookRentalDto = false, bool UserRentalDto = false)
        {
            IQueryable<Rental> query = _context.Rentals;

            query = query.AsNoTracking().Include(b => b.User).Include(b => b.Book).OrderBy(r => r.Id).Where(rental => rental.Id == rentalId);

            return query.FirstOrDefault();
        }
    }
}
