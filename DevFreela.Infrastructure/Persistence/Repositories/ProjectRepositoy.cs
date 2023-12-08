using Azure.Core;
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
    public class ProjectRepositoy : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectRepositoy(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<List<Project>> GetAllAsync()
        {
           return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetDetailsByIdAsync(int id)
        {
            return await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id);
        }


        public async Task AddAsync(Project project)
        {

            await _dbContext.Projects.AddAsync(project);

            await _dbContext.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task StartAsync(Project project)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddCommentAsync(ProjectComment projectComment)
        {
            await _dbContext.ProjectComments.AddAsync(projectComment);

            await _dbContext.SaveChangesAsync();
        }

        public async Task FinishAsync(Project project)
        {
            await _dbContext.SaveChangesAsync();
        }

         async Task<Project> IProjectRepository.GetProjectByIdAsync(int id)
        {
            return await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
