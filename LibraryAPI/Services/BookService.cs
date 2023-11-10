using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.Data.Interfaces;
using LibraryAPI.Dtos.Books;
using LibraryAPI.Dtos.Validations;
using LibraryAPI.FiltersDb;
using LibraryAPI.Models;
using LibraryAPI.Services.Interface;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IRentalRepository _rentalRepo;

        public BookService(IMapper mapper,IBookRepository bookRepository,IRentalRepository rentalRepo)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _rentalRepo = rentalRepo;
        }
        public async Task<ResultService> CreateAsync(CreateBookDto createBookDto) 
        {
            var validation = new BookDtoValidator().Validate(createBookDto);
            if (!validation.IsValid)
                return ResultService.RequestError<CreateBookDto>("Problemas de validação!", validation);

            var sameName = await _bookRepository.GetBooksByName(createBookDto.Name);
            if (sameName != null)
                return ResultService.Fail<CreateBookDto>("Livro já cadastrado!");

            if(createBookDto.Realese>DateTime.Now.Year)
                return ResultService.Fail<CreateBookDto>("Ano inválido");

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
            var book = await _bookRepository.GetBooksById(updateBookDto.Id);
            if (book == null)
                return ResultService.Fail<UpdateBookDto>("Livro não encontrado!");

            var validation = new UpdateBookDtoValidator().Validate(updateBookDto);
            if (!validation.IsValid)
                return ResultService.RequestError(validation);

            var sameName = await _bookRepository.GetBooksByName(updateBookDto.Name);
            if (sameName != null && sameName.Id!= updateBookDto.Id)
                return ResultService.Fail<CreateBookDto>("Livro já cadastrado!");

            book = _mapper.Map(updateBookDto, book);
            await _bookRepository.Update(book);
            return ResultService.Ok("Livro atualizado");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var book = await _bookRepository.GetBooksById(id);
            if (book == null)
                return ResultService.Fail<BookDto>("Livro não encontrado");

            var bookRental = await _rentalRepo.GetRentalBook(id);
                if(bookRental!=null)
                return ResultService.Fail<BookDto>("O livro está alugado.");

            await _bookRepository.Delete(book);
            return ResultService.Ok("Livro deletado.");
        }

        public async Task<PagedBaseResponse<Publisher>> GetPagedAsync(FilterDb request)
        {
            throw new NotImplementedException();
        }
    }
}
