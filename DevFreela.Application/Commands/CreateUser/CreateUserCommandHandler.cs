using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;  
            _authService = authService;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return user.Id;
        }
    }
}
