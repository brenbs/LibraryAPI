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
            RuleFor(x => x.Autor)
                    .NotEmpty()
                    .WithMessage("Autor necessário!");
            RuleFor(x => x.PublisherId)
                    .NotEmpty()
                    .WithMessage("Editora ncessária!");
            RuleFor(x => x.Realese)
                    .NotEmpty()
                    .WithMessage("Ano de lançamento ncessário!");
            RuleFor(x => x.Stock)
                    .NotEmpty()
                    .WithMessage("Estoque ncessário!");
        }
    }

    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Nome ncessário!");
        RuleFor(x => x.Autor)
            .NotEmpty()
            .WithMessage("Autor necessário!");
        RuleFor(x => x.PublisherId)
            .NotEmpty()
            .WithMessage("Editora ncessária!");
        RuleFor(x => x.Realese)
            .NotEmpty()
            .WithMessage("Ano de lançamento ncessária!");
            RuleFor(x => x.Stock)
            .NotEmpty()
            .WithMessage("Estoque ncessário!");
        }         
    }
}
