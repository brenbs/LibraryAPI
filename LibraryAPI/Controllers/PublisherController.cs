using LibraryAPI.Data;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController  : ControllerBase
    {
        private readonly IPublisherRepository _repo;

        public PublisherController(IPublisherRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllPublishers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var publisher = _repo.GetPublishersById(id);
            if (publisher == null) return BadRequest("Editora não encontrada");
            return Ok(publisher);
        }

        [HttpPost] 
        public IActionResult Post(Publisher publisher)
        {
            _repo.Add(publisher);
            if (_repo.SaveChanges())
            {
                return Ok(publisher);
            }
            return BadRequest("Editora não cadastrada");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Publisher publisher)
        {
            var publishe = _repo.GetPublishersById(id);
            if (publisher == null) return BadRequest("Editora não encontrada");
           
            _repo.Update(publisher);
            if (_repo.SaveChanges())
            {
                return Ok(publisher);
            }
            return BadRequest("Editora não cadastrada");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _repo.GetPublishersById(id);
            if (publisher == null) return BadRequest("Editora não encontrada");
            
            _repo.Delete(publisher);
            if (_repo.SaveChanges())
            {
                return Ok("Editora deletada");
            }
            return BadRequest("Editora não cadastrada");
        }
    }
}
