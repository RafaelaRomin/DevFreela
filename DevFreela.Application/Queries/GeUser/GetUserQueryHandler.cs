using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Queries.GeUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.Id);

            if (user == null)
            {
                return null;
            }
            var userViewModel = new UserViewModel(
                user.Name,
                user.Email
            );

            return userViewModel;
        }
    }
}
