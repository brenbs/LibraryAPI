using FluentValidation;
using LibraryAPI.Dtos.Users;

namespace LibraryAPI.Dtos.Validations
{
    public class UserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome ncessário!");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email necessário!")
                .EmailAddress()
                .WithMessage("Email inválido!");
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Endereço ncessário!");
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("Cidade ncessária!");
        }
    }
    public class UpdateUserDtoValidator : AbstractValidator<UserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome ncessário!");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email ncessário!");
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Endereço ncessário!");
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("Cidade ncessária!");
        }
    }
}
