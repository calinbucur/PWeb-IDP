using Petaway.Core.DataModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Petaway.Infrastructure.Data.EntityConfigurations
{
    internal class OwnersConfiguration : EntityConfiguration<Owners>
    {
        public override void Configure(EntityTypeBuilder<Owners> builder)
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
                .HasIndex(x => x.PhoneNumber)
                .IsUnique();

            builder
                .Property(x => x.Address)
                .IsRequired();

            builder
                .Property(x => x.PhotoPath);

            base.Configure(builder);
        }
    }
}
