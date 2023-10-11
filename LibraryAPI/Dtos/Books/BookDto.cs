using LibraryAPI.Dtos.Publishers;
using LibraryAPI.Models;

namespace LibraryAPI.Dtos.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Autor { get; set; }
        public int Realese { get; set; }
        public int Stock { get; set; }
        public int PublisherId { get; set; }
        public PublisherBookDto Publisher { get; set; }

    }
}
