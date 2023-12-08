using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateSkillFreelancer
{
    public class CreateSkillFreelancerCommand : IRequest<Guid>
    {
        public int IdUser { get;  set; }
        public int IdSkill { get;  set; }
    }
}
