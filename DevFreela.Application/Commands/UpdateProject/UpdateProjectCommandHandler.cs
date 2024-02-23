using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<Unit> IRequestHandler<UpdateProjectCommand, Unit>.Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.Projects.GetProjectByIdAsync(request.Id);

            project.Update(request.Title, request.Description, request.TotalCost);

            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
