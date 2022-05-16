﻿using Petaway.Core.DataModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Petaway.Infrastructure.Data.EntityConfigurations
{
    internal class RescuersConfiguration : EntityConfiguration<Rescuers>
    {
        public override void Configure(EntityTypeBuilder<Rescuers> builder)
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