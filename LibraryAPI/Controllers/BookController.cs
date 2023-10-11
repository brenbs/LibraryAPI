using AutoMapper;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Books;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase   
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;

        public BookController(IBookRepository repo,IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get() 
        { 
            var books = _repo.GetAllBooks(true);

            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        { 
            var book = _repo.GetBooksById(id,true);
            if (book == null) return BadRequest("O Livro não foi encontrado");

            var bookDto = _mapper.Map<BookDto>(book);

            return Ok(bookDto);
        }

        [HttpPost]
        public IActionResult Post(BookDto model)
        {
            var book = _mapper.Map<Book>(model);
            _repo.Add(book);
            if(_repo.SaveChanges())
            {
                return Created($"/api/book/{model.Id}", _mapper.Map<BookDto>(book));
            }
            return BadRequest("Livro não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,BookDto model) 
        {
            var book = _repo.GetBooksById(id);
            if (book == null) return BadRequest("Livro não encontrado");

            _mapper.Map(model, book);

            _repo.Update(book);
            if (_repo.SaveChanges())
            {
                return Created($"/api/book/{model.Id}", _mapper.Map<BookDto>(book));
            }
            return BadRequest("Livro não cadastrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _repo.GetBooksById(id);
            if (book == null) return BadRequest("Livro não encontrado");
            
            _repo.Delete(book);
            if(_repo.SaveChanges())
            {
                return Ok("Livro deletado");
            }
            return BadRequest("Livro não cadastrado"); ;
        }
    } 
}