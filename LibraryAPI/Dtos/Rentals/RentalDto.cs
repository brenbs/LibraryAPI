using LibraryAPI.Dtos.Books;
using LibraryAPI.Dtos.Users;

namespace LibraryAPI.Dtos.Rentals
{
    public class RentalDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserRentalDto User { get; set; }
        public int BookId { get; set; }
        public BookRentalDto Book { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ForecastDate { get; set; }
        public DateTime DevolutionDate { get; set; }
        public string? Status { get; set; }

    }
}
