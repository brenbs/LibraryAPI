namespace LibraryAPI.Models
{
    public class Rental
    {
        public Rental() { }
        public Rental(int id,int userId, int bookId)
        {
            this.Id = id;
            this.UserId = userId;
            this.BookId = bookId;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}