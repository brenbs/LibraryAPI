using AutoMapper;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Publishers;
using LibraryAPI.Dtos.Validations;
using LibraryAPI.Models;
using LibraryAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<ResultService> CreateAsync(CreatePublisherDto createPublisherDto)
        {
            if (createPublisherDto == null)
                return ResultService.Fail<CreatePublisherDto>("O objeto deve ser informado");
            var result = new PulisherDtoValidator().Validate(createPublisherDto);
            if (!result.IsValid)
                return ResultService.RequestError<CreatePublisherDto>("Problemas da validade!: ", result);

            var samePublisher = await _publisherRepository.GetPublisherByName(createPublisherDto.Name);

            if (samePublisher != null)
                return ResultService.Fail<CreatePublisherDto>("Editora já existente.");

            var publisher = _mapper.Map<Publisher>(createPublisherDto);
            await _publisherRepository.Add(publisher);
            return ResultService.Ok("Editora cadastrada.");

        }

        public async Task<ResultService<ICollection<PublisherDto>>> GetAsync()
        {
            var publisher = await _publisherRepository.GetAllPublishers();
            return ResultService.Ok<ICollection<PublisherDto>>(_mapper.Map<ICollection<PublisherDto>>(publisher));
        }

        public async Task<ResultService<PublisherDto>> GetByIdAsync(int id)
        {
            var publisher = await _publisherRepository.GetPublisherById(id);
            if(publisher == null)
            {
                return ResultService.Fail<PublisherDto>("Editora não encontrada!");
            }
            return ResultService.Ok(_mapper.Map<PublisherDto>(publisher));
        }

        public async Task<ResultService> UpdateAsync(PublisherDto publisherDto)
        {
            if (publisherDto == null)
                return ResultService.Fail<PublisherDto>("Editora não encontrada.");

            var validation = new UpdatePulisherDtoValidator().Validate(publisherDto);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas com a validação dos campos ",validation);

            var publisher = await _publisherRepository.GetPublisherById(publisherDto.Id);

            publisher = _mapper.Map<PublisherDto, Publisher>(publisherDto, publisher);
            await _publisherRepository.Update(publisher);
            return ResultService.Ok("Editora atualizada");

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var publisher = await _publisherRepository.GetPublisherById(id);
            if (publisher == null)
                return ResultService.Fail<PublisherDto>("Editora não encontrado.");

            await _publisherRepository.Delete(publisher);
            return ResultService.Ok("A editora foi deletada");
        }

    }
}
