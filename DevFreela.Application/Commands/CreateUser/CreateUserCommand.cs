using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string? FullName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Role { get;  set; }
    }
}
