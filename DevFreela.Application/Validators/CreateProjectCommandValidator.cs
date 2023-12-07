using DevFreela.Application.Commands.CreateProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(300)
                .WithMessage("Tamanho máximo da descrição é de 300 caracteres.");

            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("O tamanho máximo do titulo é de 30 caracteres");

        }
    }
}
