using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Publisher>()
                    .HasData(new List<Publisher>(){
                    new Publisher(1,"Pé da Letra","São Paulo"),
                    new Publisher(2, "JBC","Fortaleza"),
                    new Publisher(3, "MangaPop","Vitória"),
                    new Publisher(4, "Intrínseca","São Paulo"),
                    new Publisher(5, "Panini","Rio de Janeiro"),
                    });

            builder.Entity<Book>()
                .HasData(new List<Book>{
                    new Book(1,"Orgulho e Preconceito","Jane Austen",1813,25,1),
                    new Book(2,"Chainsaw Man Vol.1","Tatsuki Fujimoto",2010,20,5),
                    new Book(3,"Razão e Sensibilidade","Jane Austen", 1811,30,1 ),
                    new Book(4, "O Pequeno Príncipe","Antoine de Saint-Exupéry",1943,35,4),
                    new Book(5, "Coraline","Neil Gaiman",2002,18,4)
                });

            builder.Entity<User>()
                .HasData(new List<User>(){ 
                    new User(1, "Brenda", "brenbs@gmail.com","Álvaro Weyne rua Manoel Pereira n°489","Fortaleza,CE"),
                    new User(2,"Emauela","manhu@gmail.com","Moranguinho, rua Maria n°321","Horizonte,CE" ),
                    new User(3,"Heloísa","lolo@gmail.com","Damas, rua Professor Costa Mendes n°933","Fortaleza,CE" ),
                    new User(4, "Antonio","tonys@gmail.com","Aldeota, Av.Dom Luís n°5001","Fortaleza,CE"),
                    new User(5,"Emanuel","manel@gmail.com","Álvaro Weyne,Coelho Neto n°400","Fortaleza,CE")
                });
        }

    }

}
