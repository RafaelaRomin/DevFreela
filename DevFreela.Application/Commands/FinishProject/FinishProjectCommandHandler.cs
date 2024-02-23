using DevFreela.Core.Repositories;
using MediatR;
using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, bool>
    {
        private readonly IPaymentService _paymentService;
        private readonly IUnitOfWork _unitOfWork;

        public FinishProjectCommandHandler(IUnitOfWork unitOfWork, IPaymentService paymentService)
        {
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
        }
        public async Task<bool> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.Projects.GetDetailsByIdAsync(request.Id);

            var paymentInfoDto = new PaymentInfoDto(request.Id, request.CreditCardNumber, request.Cvv,
                                                    request.ExpiresAt, request.FullName, project.TotalCost);

            _paymentService.ProcessPayment(paymentInfoDto);
            
            project.SetPaymentPending();

            await _unitOfWork.CompleteAsync();
            
            return true;
        }
    }
}
