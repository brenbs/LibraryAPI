using FluentValidation;
using LibraryAPI.Dtos.Publishers;

namespace LibraryAPI.Dtos.Validations
{
    public class PulisherDtoValidator : AbstractValidator<CreatePublisherDto>
    {
        public PulisherDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome ncessário!");
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("Cidade ncessária!");
        }
    }
    public class UpdatePulisherDtoValidator : AbstractValidator<PublisherDto>
    {
        public UpdatePulisherDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome ncessário!");
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("Cidade ncessária!");
        }
    }
}
