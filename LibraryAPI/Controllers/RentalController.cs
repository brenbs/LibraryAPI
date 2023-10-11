using AutoMapper;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Rentals;
using LibraryAPI.Dtos.Users;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : Controller
    {
        private readonly IRentalRepository _repo;
        private readonly IMapper _mapper;

        public RentalController(IRentalRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var rentals = _repo.GetAllRentals(true);

            return Ok(_mapper.Map<IEnumerable<RentalDto>>(rentals));   
        }

        [HttpGet("{id}")] //falta so terminar a controller de rentals pra poder ver a playlist das services
        public IActionResult GetById(int id)
        {
            var rental = _repo.GetRentalsById(id,true);
            if(rental== null) return BadRequest("O Aluguél não foi encontrado");

            var rentalDto = _mapper.Map<RentalDto>(rental); 

            return Ok(rentalDto);

        }

        [HttpPost]
        public IActionResult Post(CreateRentalDto model)
        {
            var rental = _mapper.Map<Rental>(model);
            _repo.Add(rental);
            if (_repo.SaveChanges())
            {
                return Ok(rental);
            }
            return BadRequest("Aluguel não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,UpdateRentalDto model)
        {
            var rental = _repo.GetRentalsById(id);
            if (rental == null) return BadRequest("Aluguel não encontrado");

            _repo.Update(rental);
            if (_repo.SaveChanges())
            {
                return Created($"/api/rental/{model.Id}", _mapper.Map<RentalDto>(rental));
            }
            return BadRequest("Aluguel não cadastrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rental = _repo.GetRentalsById(id);
            if (rental == null) return BadRequest("Aluguel não cadastrado");

            _repo.Delete(rental);
            if (_repo.SaveChanges())
            {
                return Ok("Aluguel deletado");
            }
            return BadRequest("Aluguel não cadastrado");
        }

    }
}