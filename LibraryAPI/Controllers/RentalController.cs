using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Publishers;
using LibraryAPI.Dtos.Rentals;
using LibraryAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController:ControllerBase
    {
        private readonly IRentalRepository _repo;
        private readonly IRentalService _rentalService;

        public RentalController(IRentalRepository repo,IRentalService rentalUser)
        {
            _repo = repo;
            _rentalService = rentalUser;

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateRentalDto createRentalDto)
        {
          var result = await _rentalService.CreateAsync(createRentalDto);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);  
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _rentalService.GetAsync();
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _rentalService.GetByIdAsync(id);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateAsnc([FromBody] UpdateRentalDto updateRentalDto)
        {
            var result = await _rentalService.UpdateAsync(updateRentalDto);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _rentalService.DeleteAsync(id);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
