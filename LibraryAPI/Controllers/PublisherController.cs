using AutoMapper;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Publishers;
using LibraryAPI.FiltersDb;
using LibraryAPI.Services;
using LibraryAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _publisherService.GetAsync();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _publisherService.GetByIdAsync(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult> GetPagedAsync([FromQuery] FilterDb request)
        {
            var result = await _publisherService.GetPagedAsync(request);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] PublisherDto publisherDto)
        {
            var result = await _publisherService.UpdateAsync(publisherDto);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _publisherService.DeleteAsync(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }
        [HttpGet]
        [Route("Dash")]
        public async Task<ActionResult> GetRented()
        {
            var result = await _publisherService.Dash();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
    }
}
