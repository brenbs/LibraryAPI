using FluentValidation;
using LibraryAPI.Dtos.Books;

namespace LibraryAPI.Dtos.Validations
{
    public class BookDtoValidator : AbstractValidator<CreateBookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome ncessário!");
            RuleFor(x => x.Author)
                    .NotEmpty()
                    .WithMessage("Autor necessário!");
            RuleFor(x => x.PublisherId)
                    .NotEmpty()
                    .WithMessage("Editora necessária!");
            RuleFor(x => x.Release)
                    .NotEmpty()
                    .WithMessage("Ano de lançamento necessário!");
            RuleFor(x => x.Stock)
                    .NotEmpty()
                    .WithMessage("Estoque necessário!");
        }
    }

    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Nome ncessário!");
        RuleFor(x => x.Author)
            .NotEmpty()
            .WithMessage("Autor necessário!");
        RuleFor(x => x.PublisherId)
            .NotEmpty()
            .WithMessage("Editora ncessária!");
        RuleFor(x => x.Release)
            .NotEmpty()
            .WithMessage("Ano de lançamento ncessária!");
            RuleFor(x => x.Stock)
            .NotEmpty()
            .WithMessage("Estoque ncessário!");
        }         
    }
}
