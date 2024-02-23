using Azure.Core;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence.Models;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepositoy : IProjectRepository
    {
        private const int PAGE_SIZE = 2;
        private readonly DevFreelaDbContext _dbContext;

        public ProjectRepositoy(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginationResult<Project>> GetAllAsync(string? query, int page)
        {
            IQueryable<Project> projects = _dbContext.Projects;

            if (!string.IsNullOrWhiteSpace(query))
            {
                projects = projects
                    .Where(p =>
                        p.Title.Contains(query) ||
                        p.Description.Contains(query));
            }

            return await projects.GetPaged(page, PAGE_SIZE);
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
        }

        public async Task StartAsync(Project project)
        {
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task AddCommentAsync(ProjectComment projectComment)
        {
            await _dbContext.ProjectComments.AddAsync(projectComment);

            await _dbContext.SaveChangesAsync();
        }

        async Task<Project> IProjectRepository.GetProjectByIdAsync(int id)
        {
            return await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}