using DevFreela.Core.Repositories;

namespace DevFreela.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly DevFreelaDbContext _dbContext;
    
    public UnitOfWork(
        DevFreelaDbContext context, 
        IProjectRepository projectsRepository,
        ISkillRepository skillRepository,
        IUserRepository userRepository)
    {
        _dbContext = context;
        Projects = projectsRepository;
        Users = userRepository;
    }
    public IProjectRepository Projects { get; }
    public IUserRepository Users { get; }
    public ISkillRepository Skills { get; }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
         Dispose(true);
         GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}