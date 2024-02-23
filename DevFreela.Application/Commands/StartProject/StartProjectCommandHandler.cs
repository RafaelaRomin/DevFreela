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
        private readonly IUnitOfWork _unitOfWork;
        public StartProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {

            var project = await _unitOfWork.Projects.GetDetailsByIdAsync(request.Id);

            project.Start();

            await _unitOfWork.Projects.StartAsync(project);

            return Unit.Value;
        }
    }
}
