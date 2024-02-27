using Azure.Core;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SkillDto>> GetAll()
        {
            var skills = _dbContext.Skills;

            var skillsViewModel = await skills
                .Select(s => new SkillDto(s.Id, s.Description))
                .ToListAsync();

            return skillsViewModel;
        }

        public async Task AddSkill(Skill skill)
        {
            await _dbContext.Skills.AddAsync(skill);
        }

        public async Task AddSkillInUser(UserSkill userSkill)
        {
            await _dbContext.UserSkills.AddAsync(userSkill);
        }

        public async Task AddSkillFromProject(Project project)
        {
            var words = project.Description.Split(' ');
            var lenght = words.Length;

            var skill = $"{project.Id} - {words[lenght - 1]}";

            await _dbContext.Skills.AddAsync(new Skill(skill));
        }

        public async Task GetSkillByIdAsync(int id)
        {
            await _dbContext.Skills.SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}