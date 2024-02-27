using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace DevFreela.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly DevFreelaDbContext _dbContext;
    private IDbContextTransaction _transaction;

    public UnitOfWork(
        DevFreelaDbContext context,
        IProjectRepository projectsRepository,
        ISkillRepository skillRepository,
        IUserRepository userRepository, 
        ISkillRepository skills)
    {
        _dbContext = context;
        Projects = projectsRepository;
        Users = userRepository;
        Skills = skills;
    }

    public IProjectRepository Projects { get; }
    public IUserRepository Users { get; }
    public ISkillRepository Skills { get; }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await _transaction.RollbackAsync();
            throw ex;
        }
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