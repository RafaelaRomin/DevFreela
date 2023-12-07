using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetDetailsByIdAsync(int id);
        Task AddAsync(Project project);
        Task StartAsync(Project project);
        Task SaveChangesAsync();
        Task AddCommentAsync(ProjectComment projectComment);
        Task FinishAsync(Project project);
        Task DeleteAsync(int id);
    }
}
