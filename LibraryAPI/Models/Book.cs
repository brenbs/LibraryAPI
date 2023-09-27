using System.Collections.Generic;
namespace LibraryAPI.Models
{
    public class Book
    {
        public Book() { }
        public Book(int id, string name, string autor, int realese, int stock, int publisherId)
        {
            this.Id = id;
            this.Name = name;
            this.Autor = autor;
            this.Realese = realese;
            this.Stock = stock;
            this.PublisherId = publisherId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Autor { get; set; }
        public int Realese { get; set; }
        public int Stock { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
       // public IEnumerable<Rental> Rentals { get; set; }
    }
}
