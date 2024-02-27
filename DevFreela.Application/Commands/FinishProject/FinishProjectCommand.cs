using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommand : IRequest<bool>
    {
        public int Id { get;  set; }
        public string CreditCardNumber { get; set; }
        public string Cvv  { get; set; }
        public string ExpiresAt { get; set; }
        public string FullName { get; set; }
    }
}
