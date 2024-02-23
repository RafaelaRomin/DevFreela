using MediatR;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Queries.GetSkillById
{
    public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetSkillByIdQueryHandler(IUnitOfWork unitOfWork)     
        {
            _unitOfWork = unitOfWork;
        }
        public Task<int> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var skill = _unitOfWork.Skills.GetSkillByIdAsync(request.Id);

            return Task.FromResult(skill.Id);
        }
    }
}
