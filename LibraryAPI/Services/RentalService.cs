using AutoMapper;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Rentals;
using LibraryAPI.Dtos.Validations;
using LibraryAPI.Models;
using LibraryAPI.Services.Interface;
using System.Reflection.Metadata.Ecma335;

namespace LibraryAPI.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public RentalService(IRentalRepository rentalRepository,IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<ResultService> CreateAsync(CreateRentalDto createRentalDto)
        {
            var result = new RentalDtoValidator().Validate(createRentalDto);
            if (!result.IsValid)
                return ResultService.RequestError<CreateRentalDto>("Problemas com a validação", result);

            var sameUser = _rentalRepository.GetRentalsById(createRentalDto.UserId);
            var sameBook = _rentalRepository.GetRentalsById(createRentalDto.BookId);
            if (sameBook != null && sameUser != null)
                return ResultService.Fail<CreateRentalDto>("O usuário não pode alugar o mesmo livro");

            var rental = _mapper.Map<Rental>(createRentalDto);
            await _rentalRepository.Add(rental);
            return ResultService.Ok("Aluguel cadastrado");
        }

        public async Task<ResultService<ICollection<RentalDto>>> GetAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<ResultService<RentalDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultService> UpdateAsync(UpdateRentalDto updateRentalDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
