using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos;
using LibraryAPI.Dtos.Books;
using LibraryAPI.Dtos.Publishers;
using LibraryAPI.Dtos.Users;
using LibraryAPI.Dtos.Validations;
using LibraryAPI.FiltersDb;
using LibraryAPI.Models;
using LibraryAPI.Services.Interface;

namespace LibraryAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper, IBookRepository bookRepository)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<ResultService> CreateAsync(CreatePublisherDto createPublisherDto)
        {
            var validation = new PulisherDtoValidator().Validate(createPublisherDto);
            if (!validation.IsValid)
                return ResultService.BadRequest(validation);

            var sameName = await _publisherRepository.GetPublisherByName(createPublisherDto.Name);
            if (sameName != null)
                return ResultService.BadRequest("Editora já cadastrada.");

            var publisher = _mapper.Map<Publisher>(createPublisherDto);
            await _publisherRepository.Add(publisher);
            return ResultService.Ok("Editora cadastrada.");

        }

        public async Task<ResultService<ICollection<PublisherDto>>> GetAsync()
        {
            var publisher = await _publisherRepository.GetAllPublishers();
            return ResultService.Ok(_mapper.Map<ICollection<PublisherDto>>(publisher));
        }

        public async Task<ResultService<PublisherDto>> GetByIdAsync(int id)
        {
            var publisher = await _publisherRepository.GetPublisherById(id);
            if (publisher == null)
            {
                return ResultService.NotFound<PublisherDto>("Editora não encontrada!");
            }
            return ResultService.Ok(_mapper.Map<PublisherDto>(publisher));
        }

        public async Task<ResultService> UpdateAsync(PublisherDto publisherDto)
        {
            var publisher = await _publisherRepository.GetPublisherById(publisherDto.Id);
            if (publisher == null)
                return ResultService.NotFound("Editora não encontrada!");

            var validation = new UpdatePulisherDtoValidator().Validate(publisherDto);
            if (!validation.IsValid)
                return ResultService.BadRequest(validation);

            var sameName = await _publisherRepository.GetPublisherByName(publisherDto.Name);
            if (sameName != null && sameName.Id != publisher.Id)
                return ResultService.BadRequest("Editora já cadastrada.");

            publisher = _mapper.Map(publisherDto, publisher);
            await _publisherRepository.Update(publisher);
            return ResultService.Ok("Editora atualizada");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var publisher = await _publisherRepository.GetPublisherById(id);
            if (publisher == null)
                return ResultService.NotFound("Editora não encontrado!");

            var bookAssociation = await _bookRepository.GetPublisherAssociate(id);
            if (bookAssociation.Count > 0)
                return ResultService.BadRequest("Editora está associada a livros.");

            await _publisherRepository.Delete(publisher);
            return ResultService.Ok("Editora foi deletada.");
        }
        
        public async Task<ResultService<List<PublisherDto>>> GetPagedAsync(FilterDb request)
        {
           var publisherPaged = await _publisherRepository.GetPagedAsync(request);
           var result = new PagedBaseResponseDto<PublisherDto>(publisherPaged.TotalRegisters,publisherPaged.TotalPages,publisherPaged.Page,
                                        _mapper.Map<List<PublisherDto>>(publisherPaged.Data));
            if (result.Data.Count == 0)
                return ResultService.NotFound<List<PublisherDto>>("Nenhum Registro Encontrado");

            return ResultService.OkPaged(result.Data, result.TotalRegisters, result.TotalPages, result.Page);
        }

        public async Task<ResultService<List<PublisherDash>>> Dash()
        {
            var publishers = await _publisherRepository.GetAllPublishers();
            return ResultService.Ok(_mapper.Map<List<PublisherDash>>(publishers));
        }
    }
}