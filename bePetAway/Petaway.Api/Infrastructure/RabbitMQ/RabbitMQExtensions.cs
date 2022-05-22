using System.Text;
using System.Text.Json;
using Petaway.Core.Domain.Owner;
using Petaway.Core.Domain.Foster;
using Petaway.Core.Domain.Rescuer;
using Petaway.Core.Domain.Transport;
using Petaway.Infrastructure.Data;
using Petaway.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Petaway.Api.Infrastructure.RabbitMQ
{
    public interface IRabbitMQService
    {
        public void sendMail(string destination, string subject, string body, string? queue = null);

    }

    public class RabbitMQMessage
    {
        public string subject { get; set; } = "";
        public string to { get; set; } = "";
        public string body { get; set; } = "";
    }

    //public class RabbitMQService : IRabbitMQService
    public class RabbitMQService
    {
        public static void sendMail(string destination, string subject, string body, string? queue = "queue")
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOSTNAME") ?? "localhost",
                UserName = DataAccessExtensions.ReadFileFromEnv("RABBITMQ_DEFAULT_USER_FILE") ?? "username",
                Password = DataAccessExtensions.ReadFileFromEnv("RABBITMQ_DEFAULT_PASS_FILE") ?? "password",
            };
            const string defaultQueue = "queue";

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queue ?? defaultQueue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                RabbitMQMessage message = new RabbitMQMessage()
                {
                    body = body,
                    to = destination,
                    subject = subject,
                };

                var bodyEncoded = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

                channel.BasicPublish(exchange: "",
                    routingKey: "hello",
                    basicProperties: null,
                    body: bodyEncoded);

                Console.WriteLine($"Sent mail to {destination} with subject {subject} and body {body}.");
            }
        }
    }

    public static partial class RabbitMQExtensions
    {

        public static void AddRabbitMQ(this WebApplicationBuilder builder)
        {
            string username = DataAccessExtensions.ReadFileFromEnv("RABBITMQ_DEFAULT_USER_FILE") ?? "username";
            string password = DataAccessExtensions.ReadFileFromEnv("RABBITMQ_DEFAULT_PASS_FILE") ?? "password";
            string hostname = Environment.GetEnvironmentVariable("RABBITMQ_HOSTNAME") ?? "localhost";
            string queue = Environment.GetEnvironmentVariable("RABBITMQ_QUEUE") ?? "queue";
            //IRabbitMQService rabbitMqService = new RabbitMQService(hostname, username, password, queue);
            //builder.Services.AddSingleton(rabbitMqService);
            //builder.Services.AddTransient<IRabbitMQService, RabbitMQService>();
            
            //builder.Services.AddScoped<IRabbitMQService>(_ => rabbitMqService);
        }
    }
}
