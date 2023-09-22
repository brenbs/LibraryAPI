namespace LibraryAPI.Models
{
    public class Rental
    {
        public Rental() { }
        public Rental(int userId, int bookId)
        {
            this.UserId = userId;
            this.BookId = bookId;
        }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
