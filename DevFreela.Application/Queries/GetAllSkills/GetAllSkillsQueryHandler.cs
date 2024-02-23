using DevFreela.Core.DTOs;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllSkillsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<SkillDto>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Skills.GetAll();
        }
    }
}
