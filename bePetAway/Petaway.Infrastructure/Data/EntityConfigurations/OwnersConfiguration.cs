using Petaway.Core.DataModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Infrastructure.Data.EntityConfigurations
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
                .Property(x => x.Password)
                .IsRequired();

            builder
                .Property(x => x.Address)
                .IsRequired();

            builder
                .OwnsMany(x => x.Animals);

            base.Configure(builder);
        }
    }
}
