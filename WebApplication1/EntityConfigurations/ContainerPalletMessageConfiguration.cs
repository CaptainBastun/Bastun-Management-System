﻿namespace BMS.EntityConfigurations
{
    using BMS.Data.Models.Messages;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class ContainerPalletMessageConfiguration : IEntityTypeConfiguration<UniloadContainerMessage>
    {
        public void Configure(EntityTypeBuilder<UniloadContainerMessage> builder)
        {
            builder.HasMany(x => x.ContainerInfo)
                .WithOne(x => x.UniloadContainerMessage)
                .HasForeignKey(x => x.UniloadContainerMessageId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}