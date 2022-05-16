using Petaway.Core.DataModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Petaway.Infrastructure.Data.EntityConfigurations
{
    internal class FostersConfiguration : EntityConfiguration<Fosters>
    {
        public override void Configure(EntityTypeBuilder<Fosters> builder)
        {
            builder
                .Property(x => x.UserId)
                .IsRequired();

            builder
                .HasIndex(x => x.UserId)
                .IsUnique();

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .HasIndex(x => x.Name)
                .IsUnique();

            builder
                .Property(x => x.Password)
                .IsRequired();

            builder
                .Property(x => x.Address)
                .IsRequired();

            builder
                .Property(x => x.MaxCapacity)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
