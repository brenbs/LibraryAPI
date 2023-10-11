using LibraryAPI.Dtos.Users;

namespace LibraryAPI.Dtos.Rentals
{
    public class RentalDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserRentalDto User { get; set; }
        public int BookId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime Forecast { get; set; }
        public DateTime Devolution { get; set; }
        public string Status { get; set; } 

    }
}
