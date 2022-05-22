using Petaway.Core.DataModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Petaway.Infrastructure.Data.EntityConfigurations
{
    internal class TransportsConfiguration : EntityConfiguration<Transports>
    {
        public override void Configure(EntityTypeBuilder<Transports> builder)
        {
            builder
                .Property(x => x.OwnerEmail)
                .IsRequired();

            builder
                .Property(x => x.AnimalId)
                .IsRequired();

            builder
                .Property(x => x.FosterEmail)
                .IsRequired();

            builder
                .Property(x => x.RescuerEmail)
                .IsRequired(); //Tehnic ar putea sa fie null, dar felul cum verific transporturile se bazeaza pe RescuerEmail = null => RescuerEmail = "none"

            builder
                .Property(x => x.StartPoint);

            builder
                .Property(x => x.EndPoint);

            base.Configure(builder);
        }
    }
}
