using System;

namespace LibraryAPI.Models
{
    public class Rental
    {
        public Rental() { }
        public Rental(int id,int userId, int bookId, DateTime rentalDate, DateTime forecast, DateTime devolution)
        {
            this.Id = id;
            this.UserId = userId;
            this.BookId = bookId;
            this.RentalDate = rentalDate;
            this.Forecast = forecast;
            this.Devolution = devolution;  
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime Forecast { get; set; }
        public DateTime Devolution { get; set; } 
        public string? Status { get; set; } 

    }
}