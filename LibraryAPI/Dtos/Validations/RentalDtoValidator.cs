using FluentValidation;
using LibraryAPI.Dtos.Rentals;

namespace LibraryAPI.Dtos.Validations
{
    public class RentalDtoValidator : AbstractValidator<CreateRentalDto>
    {
        public RentalDtoValidator() 
        {
            RuleFor(x => x.UserId)
                    .NotEmpty()
                    .WithMessage("Usuário necessário!");
            RuleFor(x => x.BookId)
                .NotEmpty()
                .WithMessage("Livro necessário!");
            RuleFor(x => x.RentalDate)
                .NotEmpty()
                .WithMessage("Data de aluguel necessária!");
            RuleFor(x => x.ForecastDate)
                .NotEmpty()
                .WithMessage("Data de prevista de entrega necessária!");
        }
    }

    public class UpdateRentalDtoValidator : AbstractValidator<UpdateRentalDto>
    {
        public UpdateRentalDtoValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id necessário!");
            RuleFor(x => x.DevolutionDate)
                .NotEmpty()
                .WithMessage("Data de devolução necessária!");
        }
    }
}
