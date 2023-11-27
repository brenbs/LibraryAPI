using LibraryAPI.Dtos.Publishers;
using LibraryAPI.Models;

namespace LibraryAPI.Dtos.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Release { get; set; }
        public int Stock { get; set; }
        public int PublisherId { get; set; }
        public PublisherBookDto Publisher { get; set; }
        public int TotalRental { get; set; }

    }
}
