using Petaway.Core.DataModel;
using Petaway.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Petaway.Infrastructure.Data
{
    public class PetawayContext : DbContext
    {
        public PetawayContext(DbContextOptions<PetawayContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OwnersConfiguration).Assembly);
        }

        public DbSet<Owners> Owners => Set<Owners>();
        public DbSet<Animals> Animals => Set<Animals>();
        public DbSet<Fosters> Fosters => Set<Fosters>();
        public DbSet<Rescuers> Rescuers => Set<Rescuers>();
        public DbSet<Transports> Transports => Set<Transports>();
    }
}
