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

namespace Petaway.Api.Infrastructure.RabbitMQ
{
    public static partial class RabbitMQExtensions
    {
        //TODO
        public static void AddRabbitMQ(this WebApplicationBuilder builder)
        {

            string stackHostname = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_HOST") ?? "localhost";
            string stackUsername = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_USER") ?? "guest";
            string stackPassword = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_PASS") ?? "guest";


/*            AddRabbitMQ<PetawayContext>(opt =>
                opt.UseNpgsql(@$"Host={dbHostname};Username={dbUsername};Password={dbPassword};Database={dbDatabase}"));
*/
        }
    }
}


