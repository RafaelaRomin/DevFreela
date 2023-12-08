using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<SkillDto>> GetAll();
        Task GetSkillByIdAsync(int id);
        Task AddSkill(Skill skill);
        Task AddSkillInUser(UserSkill userSkill);
    }
}
