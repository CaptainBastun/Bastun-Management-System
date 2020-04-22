namespace BMS.EntityConfigurations
{
    using BMS.Data.LoadingInstructions;
    using BMS.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OutboundFlightConfiguration : IEntityTypeConfiguration<OutboundFlight>
    {
        public void Configure(EntityTypeBuilder<OutboundFlight> builder)
        {

            builder.HasMany(x => x.OutboundMessages)
                .WithOne(x => x.Outbound)
                .HasForeignKey(x => x.OutboundFlightFlightNumber)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Aircraft)
                .WithOne(obF => obF.OutboundFlight)
                .HasForeignKey<Aircraft>(fk => fk.OutboundFlightFlightNumber)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DepartureMovement)
                .WithOne(x => x.OutboundFlight)
                .HasForeignKey<DepartureMovement>(mvt => mvt.OutboundFlightFlightNumber)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LoadingInstruction)
                .WithOne(x => x.OutboundFlight)
                .HasForeignKey<LoadingInstruction>(li => li.OutboundFlightFlightNumber)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
