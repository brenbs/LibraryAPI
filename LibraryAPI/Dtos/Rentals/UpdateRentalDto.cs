namespace LibraryAPI.Dtos.Rentals
{
    public class UpdateRentalDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Forecast { get; set; }
        public string Devolution { get; set; } = null;
    }
}
