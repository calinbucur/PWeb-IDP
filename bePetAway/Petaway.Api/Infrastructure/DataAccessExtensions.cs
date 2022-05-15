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
    public static partial class DataAccessExtensions
    {
        public static void AddPetawayDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<PetawayContext>(opt =>
                opt.UseNpgsql(builder.Configuration.GetConnectionString("PetawayDb")));
        }

        public static void AddBookLibraryAggregateRepositories(this IServiceCollection services)
        {
            services.AddTransient<IOwnersAnimalsRepository, OwnersAnimalsRepository>();
            services.AddTransient<IFostersRepository, FostersRepository>();
            services.AddTransient<IRescuersRepository, RescuersRepository>();
            services.AddTransient<ITransportsRepository, TransportsRepository>();
        }
    }
}
