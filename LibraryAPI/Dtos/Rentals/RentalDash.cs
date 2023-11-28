using LibraryAPI.Dtos.Books;
using LibraryAPI.Dtos.Users;

namespace LibraryAPI.Dtos.Rentals
{
    public class RentalDash
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public BookRentalDto Book { get; set; }
        public int UserId { get; set; }
        public UserRentalDto User { get; set; }
    }
}
