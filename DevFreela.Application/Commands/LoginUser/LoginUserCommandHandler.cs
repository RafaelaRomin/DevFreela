using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;
        public LoginUserCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
        }
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _unitOfWork.Users.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
            {
                return null;
            }

            var token = _authService.GenerateJWTToken(user.Email, user.Role);

           return new LoginUserViewModel(user.Email, token);
        }
    }
}

