using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using BMS.Data;
using BMS.Data.LoadingInstructions;
using BMS.Data.Models;
using BMS.Data.Models.AircraftBaggageHolds;
using BMS.Data.Models.AircraftCabins;
using BMS.Data.Models.Flights;
using BMS.Data.Models.Messages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<InboundFlight> InboundFlights { get; set; }

        public DbSet<OutboundFlight> OutboundFlights { get; set; }

        public DbSet<ArrivalMovement> ArrivalMovements { get; set; }

        public DbSet<DepartureMovement> DepartureMovements { get; set; }

        public DbSet<Aircraft> Aircraft { get; set; }

        public DbSet<ContainerPalletMessage> ContainerPalletMessages { get; set; }

        public DbSet<LoadDistributionMessage> LoadDistributionMessages { get; set; }

        public DbSet<FuelForm> FuelForms { get; set; }

        public DbSet<WeightForm> WeightForms { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Container> Containers { get; set; }

        public DbSet<ContainerInfo> ContainerInfos { get; set; }

        public DbSet<Suitcase> Suitcases { get; set; }

        public DbSet<ContainerLoadingInstruction> ContainerLoadingInstructions { get; set; }

        public DbSet<BulkLoadingInstruction> BulkLoadingInstructions { get; set; }

        public DbSet<Cabin320> Cabins320 { get; set; }

        public DbSet<Cabin738> Cabins738 { get; set; }

        public DbSet<Cabin752> Cabins752 { get; set; }

        public DbSet<Cabin763> Cabins763 { get; set; }

        public DbSet<Cabin788> Cabins788 { get; set; }

        public DbSet<BaggageHoldA320> BaggageHoldsA320 { get; set; }

        public DbSet<BaggageHold738> BaggageHolds738 { get; set; }

        public DbSet<BaggageHold752> BaggageHolds752 { get; set; }

        public DbSet<BaggageHold763> BaggageHolds763 { get; set; }

        public DbSet<BaggageHold788> BaggageHolds788 { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Flight>().ToTable("Flights");
            builder.Entity<LoadingInstruction>().ToTable("LoadingInstructions");
            builder.Entity<AircraftCabin>().ToTable("AircraftCabins"); 

            base.OnModelCreating(builder);
        }
    }
}
