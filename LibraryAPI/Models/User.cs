using System.Collections.Generic;
namespace LibraryAPI.Models
{
    public class User
    {
        public User() { }
        public User(int id, string name, string email, string telephone, string adress, string city)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Telephone = telephone;
            this.Adress = adress;
            this.City = city;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
    }
}
