using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdUser, request.IdProject);

            await _unitOfWork.Projects.AddCommentAsync(comment);
            await _unitOfWork.CompleteAsync();
            
            return Unit.Value;

        }
    }
}
