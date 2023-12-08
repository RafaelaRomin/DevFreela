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

namespace DevFreela.Application.Commands.CreateSkillFreelancer
{
    public class CreateSkillFreelancerCommandHandler : IRequestHandler<CreateSkillFreelancerCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        public CreateSkillFreelancerCommandHandler(IUserRepository userRepository, ISkillRepository skillRepository)
        {
            _userRepository = userRepository;
            _skillRepository = skillRepository;
        }

        public async Task<Guid> Handle(CreateSkillFreelancerCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetByIdAsync(request.IdUser);

            var skill = _skillRepository.GetSkillByIdAsync(request.IdSkill);

            var addSkillToUser = new UserSkill(request.IdUser, request.IdSkill);

            if (!user.Role.Equals("Freelancer", StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception("Você não é freelancer");
            }
            
            await _skillRepository.AddSkillInUser(addSkillToUser);

            return Guid.NewGuid();

        }
    }
}
