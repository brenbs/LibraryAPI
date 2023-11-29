using AutoMapper;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Books;
using LibraryAPI.FiltersDb;
using LibraryAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _repo;
        private readonly IBookService _bookService;

        public BookController(IMapper mapper,IBookRepository repo, IBookService bookService)
        {
            _mapper = mapper;
            _repo = repo;
            _bookService = bookService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateBookDto createBookDto)
        {
            var result = await _bookService.CreateAsync(createBookDto);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _bookService.GetAsync();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _bookService.GetByIdAsync(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update([FromBody] UpdateBookDto updateBookDto)
        {
            var result = await _bookService.UpdateAsync(updateBookDto);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _bookService.DeleteAsync(id);
            if (result.StatusCode == HttpStatusCode.OK)
                return StatusCode(201, result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return BadRequest(result);
        }
        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult> GetPagedAsync([FromQuery] FilterDb request)
        {
            var result = await _bookService.GetPagedAsync(request);
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
        [HttpGet]
        [Route("Dash")]
        public async Task<ActionResult> GetRented()
        {
            var result = await _bookService.Dash();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }

        [HttpGet]
        [Route("select")]
        public async Task<ActionResult> SelectBook()
        {
            var result = await _bookService.SelectBook();
            if (result.StatusCode == HttpStatusCode.OK)
                return Ok(result);
            return NotFound(result);
        }
    }
}
