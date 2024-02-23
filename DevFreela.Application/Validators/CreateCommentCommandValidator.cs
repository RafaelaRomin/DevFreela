using DevFreela.Application.Commands.CreateComment;
using FluentValidation;

namespace DevFreela.Application.Validators;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(c => c.Content)
            .MaximumLength(255)
            .WithMessage("O texto máximo para um comentário é de 200 caracteres");
    }
    
}