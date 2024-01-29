using DevFreela.Core.Repositories;
using MediatR;
using DevFreela.Core.DTOs;
using DevFreela.Core.Services;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, bool>
    {
        private readonly IPaymentService _paymentService;
        private readonly IProjectRepository _projectRepository;

        public FinishProjectCommandHandler(IProjectRepository repository, IPaymentService paymentService)
        {
            _projectRepository = repository;
            _paymentService = paymentService;
        }
        public async Task<bool> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetDetailsByIdAsync(request.Id);

            var paymentInfoDto = new PaymentInfoDto(request.Id, request.CreditCardNumber, request.Cvv,
                                                    request.ExpiresAt, request.FullName, project.TotalCost);

            _paymentService.ProcessPayment(paymentInfoDto);
            
            project.SetPaymentPending();

            await _projectRepository.SaveChangesAsync();
            
            return true;
        }
    }
}
