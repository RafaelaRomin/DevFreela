using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence.Models;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<PaginationResult<Project>> GetAllAsync(string? query, int page = 1);
        Task<Project> GetDetailsByIdAsync(int id);
        Task<Project> GetProjectByIdAsync(int id);
        Task AddAsync(Project project);
        Task StartAsync(Project project);
        Task AddCommentAsync(ProjectComment projectComment);
    }
}
