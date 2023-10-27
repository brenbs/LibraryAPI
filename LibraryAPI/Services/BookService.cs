using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Books;
using LibraryAPI.Dtos.Validations;
using LibraryAPI.Models;
using LibraryAPI.Services.Interface;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public BookService(IMapper mapper,IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<ResultService> CreateAsync(CreateBookDto createBookDto)
        {
            var result = new BookDtoValidator().Validate(createBookDto);
            if (!result.IsValid)
                return ResultService.RequestError<CreateBookDto>("Problemas de validação!", result);

            var sameName = await _bookRepository.GetBooksByName(createBookDto.Name);
            if (sameName != null)
                return ResultService.Fail<CreateBookDto>("Livro já cadastrado!");

            var book = _mapper.Map<Book>(createBookDto);
            await _bookRepository.Add(book);
            return ResultService.Ok("Livro cadastrado");
        }

        public async Task<ResultService<ICollection<BookDto>>> GetAsync()
        {
           var book = await _bookRepository.GetAllBooks();
            return ResultService.Ok(_mapper.Map<ICollection<BookDto>>(book));
        }

        public async Task<ResultService<BookDto>> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetBooksById(id);
            if (book == null)
                return ResultService.Fail<BookDto>("Livro não encontrado");

            return ResultService.Ok(_mapper.Map<BookDto>(book));
        }

        public async Task<ResultService> UpdateAsync(UpdateBookDto updateBookDto)
        {
            if (updateBookDto == null)
                return ResultService.Fail<UpdateBookDto>("Preencha os campos corretamente");

            var book = await _bookRepository.GetBooksById(updateBookDto.Id);
            if (book == null)
                return ResultService.Fail<UpdateBookDto>("Livro não encontrado!");

            var validation = new UpdateBookDtoValidator().Validate(updateBookDto);
            if (!validation.IsValid)
                return ResultService.RequestError(validation);

            book = _mapper.Map<UpdateBookDto, Book>(updateBookDto, book);
            await _bookRepository.Update(book);
            return ResultService.Ok("Livro atualizado");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var book = await _bookRepository.GetBooksById(id);
            if (book == null)
                return ResultService.Fail<BookDto>("Livro não encontrado");

            await _bookRepository.Delete(book);
            return ResultService.Ok("Livro deletado.");
        }
    }
}
