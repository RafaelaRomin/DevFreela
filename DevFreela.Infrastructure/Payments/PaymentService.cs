using System.Text;
using System.Text.Json;
using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace DevFreela.Infrastructure.Payments;

public class PaymentService : IPaymentService
{
    private readonly IMessageBusService _messageBusService;
    private const string queueName = "Payments";
    public PaymentService(IMessageBusService messageBusService)
    {
        _messageBusService = messageBusService;
    }

    public void ProcessPayment(PaymentInfoDto paymentInfoDto)
    {
        var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDto);

        var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);
        
        _messageBusService.Publish(queueName, paymentInfoBytes);
    }
}

