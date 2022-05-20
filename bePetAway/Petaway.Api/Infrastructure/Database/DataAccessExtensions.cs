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

namespace Petaway.Api.Infrastructure.Database
{
    public static partial class DataAccessExtensions
    {
        public static void AddPetawayDbContext(this WebApplicationBuilder builder)
        {
            string dbHostname = Environment.GetEnvironmentVariable("DB_HOSTNAME") ?? "localhost";
            string dbUsername = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "user";
            string dbPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "password";
            string dbDatabase = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "db";


            builder.Services.AddDbContext<PetawayContext>(opt =>
                opt.UseNpgsql(@$"Host={dbHostname};Username={dbUsername};Password={dbPassword};Database={dbDatabase}"));
        }

        public static void AddPetawayAggregateRepositories(this IServiceCollection services)
        {
            services.AddTransient<IOwnersAnimalsRepository, OwnersAnimalsRepository>();
            services.AddTransient<IFostersRepository, FostersRepository>();
            services.AddTransient<IRescuersRepository, RescuersRepository>();
            services.AddTransient<ITransportsRepository, TransportsRepository>();
        }
    }
}
