using Petaway.Core.DataModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Petaway.Infrastructure.Data.EntityConfigurations
{
    internal class TransportsConfiguration : EntityConfiguration<Transports>
    {
        public override void Configure(EntityTypeBuilder<Transports> builder)
        {
            builder
                .Property(x => x.OwnerId)
                .IsRequired();

            builder
                .Property(x => x.AnimalId)
                .IsRequired();

            builder
                .Property(x => x.FosterId)
                .IsRequired();

            builder
                .Property(x => x.RescuerId)
                .IsRequired();

            builder
                .Property(x => x.StartPoint);

            builder
                .Property(x => x.EndPoint);

            base.Configure(builder);
        }
    }
}
