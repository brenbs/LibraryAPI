using System.Collections.Generic;
namespace LibraryAPI.Models
{
    public class Book
    {
        public Book() { }
        public Book(int id, string name, string author, int release, int stock, int publisherId, int totalRental)
        {
            this.Id = id;
            this.Name = name;
            this.Author = author;
            this.Release = release;
            this.Stock = stock;
            this.PublisherId = publisherId;
            this.TotalRental = totalRental;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Release { get; set; }
        public int Stock { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int TotalRental { get; set; }
    }
}
