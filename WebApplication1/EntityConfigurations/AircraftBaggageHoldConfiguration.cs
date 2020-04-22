namespace BMS.EntityConfigurations
{
    using BMS.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
