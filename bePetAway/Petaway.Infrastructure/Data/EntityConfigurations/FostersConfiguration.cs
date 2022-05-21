using Petaway.Core.DataModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Petaway.Infrastructure.Data.EntityConfigurations
{
    internal class FostersConfiguration : EntityConfiguration<Fosters>
    {
        public override void Configure(EntityTypeBuilder<Fosters> builder)
        {
            builder
               .Property(x => x.IdentityId)
               .IsRequired();

            builder
                .HasIndex(x => x.IdentityId)
                .IsUnique();

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .IsRequired();

            builder
                .HasIndex(x => x.Email)
                .IsUnique();

            builder
                .Property(x => x.PhoneNumber)
                .IsRequired();

            builder
                .Property(x => x.Address)
                .IsRequired();

            builder
                .Property(x => x.PhotoPath);

            builder
                .Property(x => x.MaxCapacity)
                .IsRequired();

            /*builder
                .Property(x => x.AnimalType);

            builder
                .Property(x => x.IsAggresive);

            builder
                .Property(x => x.IsSick);

            builder
                .Property(x => x.IsStray);*/

            base.Configure(builder);
        }
    }
}
