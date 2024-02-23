using DevFreela.Application.Commands.UpdateProject;
using FluentValidation;

namespace DevFreela.Application.Validators;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(p => p.Description)
            .MaximumLength(300)
            .WithMessage("Tamanho máximo da descrição é de 300 caracteres.");

        RuleFor(p => p.Title)
            .MaximumLength(30)
            .WithMessage("O tamanho máximo do titulo é de 30 caracteres");
    }
}