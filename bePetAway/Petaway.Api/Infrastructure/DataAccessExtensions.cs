using Petaway.Core.Domain.Owner;
using Petaway.Core.Domain.Foster;
using Petaway.Core.Domain.Rescuer;
using Petaway.Core.Domain.Transport;
using Petaway.Infrastructure.Data;
using Petaway.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Petaway.Api.Infrastructure
{
    public static partial class DataAccessExtensions
    {
        public static string? ReadFileFromEnv(string env) {
            string? path = Environment.GetEnvironmentVariable(env);
            if (path != null) {
                try {
                    return System.IO.File.ReadAllText(path);
                } catch {
                    return null;
                }
            } else {
                return null;
            }
        }

        public static void AddPetawayDbContext(this WebApplicationBuilder builder)
        {
            string dbHostname = Environment.GetEnvironmentVariable("DB_HOSTNAME") ?? "localhost";
            string dbUsername = ReadFileFromEnv("POSTGRES_USER_FILE") ?? "user";
            string dbPassword = ReadFileFromEnv("POSTGRES_PASSWORD_FILE") ?? "password";
            string dbDatabase = ReadFileFromEnv("POSTGRES_DB_FILE") ?? "db";


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
