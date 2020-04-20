namespace BMS.EntityConfigurations
{
    using BMS.Data.Models.BaggageHolds.AircraftBaggageHolds;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class AircraftCompartmentConfiguration : IEntityTypeConfiguration<Compartment>
    {
        public void Configure(EntityTypeBuilder<Compartment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Suitcases)
                .WithOne(x => x.Compartment)
                .HasForeignKey(x => x.CompartmentId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
