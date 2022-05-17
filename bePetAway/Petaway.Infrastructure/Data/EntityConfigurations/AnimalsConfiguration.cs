using Petaway.Core.DataModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Petaway.Infrastructure.Data.EntityConfigurations
{
    internal class AnimalssConfiguration : EntityConfiguration<Animals>
    {
        public override void Configure(EntityTypeBuilder<Animals> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Type)
                .IsRequired();

            builder
                .Property(x => x.Status)
                .IsRequired();

            builder
                .Property(x => x.IsAggresive)
                .IsRequired();

            builder
                .Property(x => x.IsSick)
                .IsRequired();

            builder
                .Property(x => x.IsStray)
                .IsRequired();

            builder
                .Property(x => x.Age)
                .IsRequired();

            builder
                .Property(x => x.Description);

            builder
                .Property(x => x.Location)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
