using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public StartProjectCommandHandler(IProjectRepository repository)
        {
            _projectRepository = repository;
        }
        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {

            var project = await _projectRepository.GetDetailsByIdAsync(request.Id);

            project.Start();

            await _projectRepository.StartAsync(project);

            return Unit.Value;
        }
    }
}
