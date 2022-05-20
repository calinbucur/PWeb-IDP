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

namespace Petaway.Api.Infrastructure
{
    public static partial class RabbitMQExtensions
    {
        //TODO
        public static void AddRabbitMQ(this WebApplicationBuilder builder)
        {

        }
    }
}
