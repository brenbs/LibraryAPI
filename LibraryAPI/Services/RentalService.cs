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

        public RentalService(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<ResultService> CreateAsync(CreateRentalDto createRentalDto)
        {
            var validation = new RentalDtoValidator().Validate(createRentalDto);
            if (!validation.IsValid)
                return ResultService.RequestError<CreateRentalDto>("Problemas com a validação", validation);

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
                return ResultService.Fail<RentalDto>("Aluguel não encontrado");
            return ResultService.Ok(_mapper.Map<RentalDto>(rental));
        }

        public async Task<ResultService> UpdateAsync(UpdateRentalDto updateRentalDto)
        {
            if (updateRentalDto == null)
                return ResultService.Fail<UpdateRentalDto>("Aluguel não encontrado");

            var rental = await _rentalRepository.GetRentalsById(updateRentalDto.Id);
            if (rental == null)
                return ResultService.Fail<UpdateRentalDto>("Aluguel não encontrado");

            var validation = new UpdateRentalDtoValidator().Validate(updateRentalDto);
            if (!validation.IsValid)
                return ResultService.RequestError(validation);

            if (rental.Forecast.Date >=rental.Devolution.Date)
            {
              rental.Status = "No prazo";
            }
            else
            {
                rental.Status = "Em atraso";
            }
            rental = _mapper.Map(updateRentalDto, rental);
            await _rentalRepository.Update(rental);

            return ResultService.Ok("Aluguel atualizado com sucesso");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var rental = await _rentalRepository.GetRentalsById(id);
            if (rental == null)
                return ResultService.Fail<RentalDto>("Aluguel não encontrado");

            await _rentalRepository.Delete(rental);
            return ResultService.Ok("Aluguel deletado com sucesso");
        }
    }
}