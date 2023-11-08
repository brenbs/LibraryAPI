using AutoMapper;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Publishers;
using LibraryAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController :ControllerBase
    {
        private readonly IPublisherRepository _repo;
        private readonly IMapper _mapper;
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherRepository repo, IMapper mapper, IPublisherService publisherService)
        {
            _repo = repo;
            _mapper = mapper;
            _publisherService = publisherService;   
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePublisherDto createPublisherDto)
        {
            var result = await _publisherService.CreateAsync(createPublisherDto);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _publisherService.GetAsync();
            if(result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _publisherService.GetByIdAsync(id);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] PublisherDto publisherDto)
        {
            var result = await _publisherService.UpdateAsync(publisherDto);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _publisherService.DeleteAsync(id);
            if(result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
