using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Publishers;
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
        private readonly IMapper _mapper;

        public PublisherController(IPublisherRepository repo, IMapper mapper)
        {
            _repo = repo;
           _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var publishers = _repo.GetAllPublishers();

            return Ok(_mapper.Map<IEnumerable<PublisherDto>>(publishers));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var publisher = _repo.GetPublishersById(id);
            if (publisher == null) return BadRequest("Editora não encontrada");
            
            var publisherDto = _mapper.Map<PublisherDto>(publisher);

            return Ok(publisherDto);
        }

        [HttpPost] 
        public IActionResult Post(CreatePublisherDto model)
        {
            var publisher = _mapper.Map<Publisher>(model);

            _repo.Add(publisher);
            if (_repo.SaveChanges())
            {
                return Ok(_mapper.Map<Publisher>(publisher));
            }
            return BadRequest("Editora não cadastrada");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, PublisherDto model)
        {
            var publisher = _repo.GetPublishersById(id);
            if (publisher == null) return BadRequest("Editora não encontrada");

            _mapper.Map(model, publisher);

            _repo.Update(publisher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/publisher/{model.Id}", _mapper.Map<PublisherDto>(publisher));
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