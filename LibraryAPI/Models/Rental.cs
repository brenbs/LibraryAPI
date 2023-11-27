using System;

namespace LibraryAPI.Models
{
    public class Rental
    {
        public Rental() { }
        public Rental(int id,int userId, int bookId, DateTime rentalDate, DateTime forecastDate, DateTime devolutionDate)
        {
            this.Id = id;
            this.UserId = userId;
            this.BookId = bookId;
            this.RentalDate = rentalDate;
            this.ForecastDate = forecastDate;
            this.DevolutionDate = devolutionDate;  
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ForecastDate { get; set; }
        public DateTime? DevolutionDate { get; set; } 
        public string? Status { get; set; } 

    }
}