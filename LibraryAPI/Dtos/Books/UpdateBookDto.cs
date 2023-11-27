﻿namespace LibraryAPI.Dtos.Books
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Release { get; set; }
        public int Stock { get; set; }
        public int PublisherId { get; set; }
    }
}
