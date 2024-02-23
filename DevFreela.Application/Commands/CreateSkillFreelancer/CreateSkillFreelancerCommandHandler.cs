using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Commands.CreateSkillFreelancer
{
    public class CreateSkillFreelancerCommandHandler : IRequestHandler<CreateSkillFreelancerCommand, Guid>
    {

        private readonly IUnitOfWork _unitOfWork;
        public CreateSkillFreelancerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateSkillFreelancerCommand request, CancellationToken cancellationToken)
        {

            var user = await _unitOfWork.Users.GetByIdAsync(request.IdUser);

            var skill = _unitOfWork.Skills.GetSkillByIdAsync(request.IdSkill);

            var addSkillToUser = new UserSkill(request.IdUser, request.IdSkill);

            if (!user.Role.Equals("Freelancer", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception("Você não é freelancer");
            }
            
            await _unitOfWork.Skills.AddSkillInUser(addSkillToUser);
            await _unitOfWork.CompleteAsync();

            return Guid.NewGuid();

        }
    }
}
