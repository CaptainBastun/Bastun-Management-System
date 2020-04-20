using BMS.Data.Models.Cabins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.EntityConfigurations
{
    public class AircraftCabinZoneConfiguration : IEntityTypeConfiguration<AircraftCabinZone>
    {
        public void Configure(EntityTypeBuilder<AircraftCabinZone> builder)
        {
            builder.HasMany(x => x.Passengers)
                .WithOne(x => x.Zone)
                .HasForeignKey(x => x.AircraftCabinZoneId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
