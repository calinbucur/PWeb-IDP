using Petaway.Core.DataModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Petaway.Infrastructure.Data.EntityConfigurations
{
    internal class OwnersConfiguration : EntityConfiguration<Owners>
    {
        public override void Configure(EntityTypeBuilder<Owners> builder)
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
                .Property(x => x.Address)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
