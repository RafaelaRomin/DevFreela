using DevFreela.Core.Repositories;
using Microsoft.Identity.Client;

namespace DevFreela.Infrastructure.Persistence;

public interface IUnitOfWork
{
    IProjectRepository Projects { get; }
    IUserRepository Users { get; }
    ISkillRepository Skills { get; }
    Task<int> CompleteAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
}