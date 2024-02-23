using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using DevFreela.Infrastructure.Persistence.Models;

namespace DevFreela.Application.Queries.GelAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, PaginationResult<ProjectViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllProjectsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public async Task<PaginationResult<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var paginationProjects = await _unitOfWork.Projects.GetAllAsync(request.Query, request.Page);

            var projectsViewModel = paginationProjects
                .Data
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            var paginationProjectsViewModel = new PaginationResult<ProjectViewModel>(
                paginationProjects.Page,
                paginationProjects.TotalPages,
                paginationProjects.PageSize,
                paginationProjects.ItemsCount,
                projectsViewModel);
            
            return paginationProjectsViewModel;
        }
    }
}
