using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Rentals;
using LibraryAPI.Dtos.Users;
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
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        public RentalService(IRentalRepository rentalRepository, IMapper mapper,IUserRepository userRepository,IBookRepository bookRepository)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public async Task<ResultService> CreateAsync(CreateRentalDto createRentalDto)
        {
            var validation = new RentalDtoValidator().Validate(createRentalDto);
            if (!validation.IsValid)
                return ResultService.RequestError<CreateRentalDto>("Problemas com a validação", validation);

            var user = await _userRepository.GetuserById(createRentalDto.UserId);
            if (user == null)
                return ResultService.Fail<UserDto>("Usuário não encontrado!");

            var book = await _bookRepository.GetBooksById(createRentalDto.BookId);
            if (book == null)
                return ResultService.Fail<UserDto>("Livro não encontrado!");

            if(createRentalDto.RentalDate.Date!= DateTime.Now.Date)
                return ResultService.Fail<UserDto>("A data de aluguél só pode ser a de hoje!");

            var diff = createRentalDto.ForecastDate.Date.Subtract(DateTime.Now.Date);
            if (diff.Days > 30)
            {
                return ResultService.Fail<CreateRentalDto>("A data de previsão deve ser máximo 30 dias.");
            }

            var rental = _mapper.Map<Rental>(createRentalDto);

            rental.Status = "Pendente";

            var sameRental = await _rentalRepository.GetBookUser(createRentalDto.BookId, createRentalDto.UserId);
            if (sameRental != null && rental.Status == "Pendente")
                return ResultService.Fail<CreateRentalDto>("O usuário não pode alugar o mesmo livro");

            await _rentalRepository.Add(rental);
            return ResultService.Ok("Aluguel cadastrado");
        }

        public async Task<ResultService<ICollection<RentalDto>>> GetAsync()
        {
            var rental = await _rentalRepository.GetAllRentals();
            return ResultService.Ok(_mapper.Map<ICollection<RentalDto>>(rental));
        }
        public async Task<ResultService<RentalDto>> GetByIdAsync(int id)
        {
            var rental = await _rentalRepository.GetRentalsById(id);
            if (rental == null)
                return ResultService.Fail<RentalDto>("Aluguel não encontrado!");
            return ResultService.Ok(_mapper.Map<RentalDto>(rental));
        }

        public async Task<ResultService> UpdateAsync(UpdateRentalDto updateRentalDto)
        {
            var rental = await _rentalRepository.GetRentalsById(updateRentalDto.Id);
            if (rental == null)
                return ResultService.Fail<UpdateRentalDto>("Aluguel não encontrado!");

            var validation = new UpdateRentalDtoValidator().Validate(updateRentalDto);
            if (!validation.IsValid)
                return ResultService.RequestError(validation);

            if (updateRentalDto.DevolutionDate != DateTime.Now)
                return ResultService.Fail<UpdateRentalDto>("O livro só pode ser devolvido no dia atual!");

            if (rental.ForecastDate.Date >=rental.DevolutionDate.Date)
            {
              rental.Status = "No prazo";
            }
            else
            {
                rental.Status = "Em atraso";
            }
            rental = _mapper.Map(updateRentalDto, rental);
            await _rentalRepository.Update(rental);

            return ResultService.Ok("Aluguel atualizado com sucesso!");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var rental = await _rentalRepository.GetRentalsById(id);
            if (rental == null)
                return ResultService.Fail<RentalDto>("Aluguel não encontrado!");

            await _rentalRepository.Delete(rental);
            return ResultService.Ok("Aluguel deletado com sucesso1");
        }
    }
}