using System.Collections.Generic;
namespace LibraryAPI.Models
{
    public class User
    {
        public User() { }
        public User(int id, string name, string email, string address, string city)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Address = address;
            this.City = city;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
