namespace LibraryAPI.Dtos.Rentals
{
    public class CreateRentalDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime Forecast { get; set; }
    }
}
