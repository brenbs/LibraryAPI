using AutoMapper;
using LibraryAPI.Dtos.Books;
using LibraryAPI.Dtos.Publishers;
using LibraryAPI.Dtos.Rentals;
using LibraryAPI.Dtos.Users;
using LibraryAPI.Models;

namespace LibraryAPI.Mapp
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            //Users
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UserRentalDto>().ReverseMap();
            CreateMap<User, UserDash>().ReverseMap();

            //Books
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Publisher, PublisherBookDto>().ReverseMap();
            CreateMap<Book,BookRentalDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
            CreateMap<Book, BookDash>().ReverseMap();


            //Publsihers
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Publisher, CreatePublisherDto>().ReverseMap();
            CreateMap<Publisher, PublisherDash>().ReverseMap();

            //Rentals
            CreateMap<Rental, RentalDto>().ReverseMap();
            CreateMap<Rental, CreateRentalDto>().ReverseMap();
            CreateMap<Rental, UpdateRentalDto>().ReverseMap();
            CreateMap<Rental, RentalDash>().ReverseMap();

        }
    }
}
