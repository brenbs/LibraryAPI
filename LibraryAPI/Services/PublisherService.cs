using AutoMapper;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Publishers;
using LibraryAPI.Dtos.Validations;
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
                return ResultService.RequestError<CreatePublisherDto>("Problemas da validade!: ", validation);

            var sameName = await _publisherRepository.GetPublisherByName(createPublisherDto.Name);
            if (sameName != null)
                return ResultService.Fail<CreatePublisherDto>("Editora já existente.");

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
                return ResultService.Fail<PublisherDto>("Editora não encontrada!");
            }
            return ResultService.Ok(_mapper.Map<PublisherDto>(publisher));
        }

        public async Task<ResultService> UpdateAsync(PublisherDto publisherDto)
        {
            var publisher = await _publisherRepository.GetPublisherById(publisherDto.Id);
            if (publisher == null)
                return ResultService.Fail<PublisherDto>("Editora não encontrada.");

            var validation = new UpdatePulisherDtoValidator().Validate(publisherDto);
            if (!validation.IsValid)
                return ResultService.RequestError(validation);

            var sameName = await _publisherRepository.GetPublisherByName(publisherDto.Name);
            if (sameName != null && sameName.Id != publisher.Id)
                return ResultService.Fail<CreatePublisherDto>("Editora já existente.");

            publisher = _mapper.Map(publisherDto, publisher);
            await _publisherRepository.Update(publisher);
            return ResultService.Ok("Editora atualizada");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var publisher = await _publisherRepository.GetPublisherById(id);
            if (publisher == null)
                return ResultService.Fail<PublisherDto>("Editora não encontrado.");

            var bookAssociation = await _bookRepository.GetPublisherAssociate(id);
            if (bookAssociation.Count > 0)
                return ResultService.Fail<PublisherDto>("Editora está associada a livros.");

            await _publisherRepository.Delete(publisher);
            return ResultService.Ok("Editora foi deletada");
        }
    }
}
