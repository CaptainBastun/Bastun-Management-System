namespace BMS.EntityConfigurations
{
    using BMS.Data.Models;
    using BMS.Data.Models.BaggageHolds.AircraftBaggageCompartments;
    using BMS.Data.Models.BaggageHolds.AircraftBaggageHolds;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AircraftBaggageHoldConfiguration : IEntityTypeConfiguration<AircraftBaggageHold>
    {
        public void Configure(EntityTypeBuilder<AircraftBaggageHold> builder)
        {
            builder.HasMany(x => x.Compartments)
                .WithOne(x => x.BaggageHold)
                .HasForeignKey(x => x.BaggageHoldId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
