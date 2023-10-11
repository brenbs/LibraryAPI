namespace LibraryAPI.Dtos.Rentals
{
    public class CreateRentalDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string RentalDate { get; set; }
        public string Forecast { get; set; }
    }
}
