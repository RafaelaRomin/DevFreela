using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProjectByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
           
            var project = await _unitOfWork.Projects.GetDetailsByIdAsync(request.Id);

            if (project == null) return null;

            var projectDatailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.CreatedAt,
                project.FinishedAt,
                project.Client.Name,
                project.Freelancer.Name
                );

            return projectDatailsViewModel;
        }
    }
}
