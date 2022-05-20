/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Petaway.Api.Infrastructure.RabbitMQ
{
    public interface IRabbitMqService
    {
        IConnection CreateChannel();
    }

    public class RabbitMQExtensions
    {
        private readonly RabbitMqConfiguration _configuration;

        public IConnection CreateChannel()
        {
            ConnectionFactory connection = new ConnectionFactory()
            {
                UserName = _configuration.Username,
                Password = _configuration.Password,
                HostName = _configuration.HostName
            };
            connection.DispatchConsumersAsync = true;
            var channel = connection.CreateConnection();
            return channel;
        }
    }

}
*/