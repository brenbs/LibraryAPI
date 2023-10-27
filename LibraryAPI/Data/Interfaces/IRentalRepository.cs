using LibraryAPI.Models;

namespace LibraryAPI.Data.Interfaces
{
    public interface IRentalRepository
    {
        Task<Rental> Add(Rental rental);
        Task Update(Rental rental);
        Task Delete(Rental rental);
        Task <ICollection<Rental>> GetAllRentals();
        Task <Rental> GetRentalsById(int rentalId);
        Task<Rental> GetBookUser(int userId, int bookId);
        Task<Rental> GetRentalUser(int userId);
        Task<Rental> GetRentalBook(int bookId);
    }
}
