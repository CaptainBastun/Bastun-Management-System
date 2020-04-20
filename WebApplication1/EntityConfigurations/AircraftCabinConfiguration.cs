namespace BMS.EntityConfigurations
{
    using BMS.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class AircraftCabinConfiguration : IEntityTypeConfiguration<AircraftCabin>
    {
        public void Configure(EntityTypeBuilder<AircraftCabin> builder)
        {
            builder.HasMany(x => x.Zones)
                .WithOne(x => x.Cabin)
                .HasForeignKey(x => x.AircraftCabinId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
