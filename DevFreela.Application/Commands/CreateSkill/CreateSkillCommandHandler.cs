using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Commands.CreateSkill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateSkillCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = new Skill(request.Description);

            await _unitOfWork.Skills.AddSkill(skill);
            await _unitOfWork.CompleteAsync();
            
            return skill.Id;
        }
    }
}
