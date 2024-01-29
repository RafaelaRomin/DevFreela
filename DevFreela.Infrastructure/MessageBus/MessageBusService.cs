using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using DevFreela.Core.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace DevFreela.Infrastructure.MessageBus;

public class MessageBusService : IMessageBusService
{
    private readonly ConnectionFactory _factory;

    public MessageBusService()
    {
        _factory = new ConnectionFactory() 
        {
            HostName = "localhost"
        };
    }

    public void Publish(string queue, byte[] message)
    {
        using (var connection = _factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: queue,
                    basicProperties: null,
                    body: message);
            }
        }
    }
}