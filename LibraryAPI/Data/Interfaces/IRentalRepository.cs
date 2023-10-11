using LibraryAPI.Models;

namespace LibraryAPI.Data.Interfaces
{
    public interface IRentalRepository
    {
        void Add<T>(T enity) where T : class;
        void Update<T>(T enity) where T : class;
        void Delete<T>(T enity) where T : class;
        bool SaveChanges();

        public Rental[] GetAllRentals(bool BookRentalDto = false, bool UserRentalDto = false);
        public Rental GetRentalsById(int rentalId, bool BookRentalDto = false, bool UserRentalDto = false);
    }
}
