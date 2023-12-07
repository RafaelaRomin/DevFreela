using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail não é válido!");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("A senha deve conter pelo menos 8 caracteres, um número, uma letra maíuscula, uma minúscula, e um caractere especial.");

            RuleFor(p => p.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo nome não pode ser nulo ou vazio!");

        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
