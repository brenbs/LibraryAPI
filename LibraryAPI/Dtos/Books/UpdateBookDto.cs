namespace LibraryAPI.Dtos.Books
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Autor { get; set; }
        public int Realese { get; set; }
        public int Stock { get; set; }
        public int PublisherId { get; set; }
    }
}
