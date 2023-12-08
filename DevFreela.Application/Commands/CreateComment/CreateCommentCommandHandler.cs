using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public CreateCommentCommandHandler(IProjectRepository repository)
        {
            _projectRepository = repository;
        }
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdUser, request.IdProject);

            await _projectRepository.AddCommentAsync(comment);

            return Unit.Value;

        }
    }
}
