using Petaway.Core.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Petaway.Infrastructure.Data.EntityConfigurations
{
    internal abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .Property(x => x.CreatedAt)
                .HasDefaultValueSql("now()"); //getdate() sau now()
        
            builder
                .Property(x => x.UpdatedAt)
                .HasDefaultValueSql("now()");
        }
    }
}
