namespace BMS.Services
{
    using BMS.Data.LoadingInstructions;
    using BMS.Data.Models;
    using BMS.Data.Models.BaggageHolds.AircraftBaggageHolds;
    using BMS.Data.Models.Cabins;
    using BMS.Services.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApplication1.Data;

    public class AircraftCabinBaggageHoldService : IAircraftCabinBaggageHoldService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICabinAndHoldUtilityService _utilityService;

        public AircraftCabinBaggageHoldService(ApplicationDbContext dbContext, ICabinAndHoldUtilityService utilityService)
        {
            _dbContext = dbContext;
            _utilityService = utilityService;
        }


        public async Task CreateCabinAndZones(OutboundFlight flight)
        {
            var aircraftCabin = new AircraftCabin
            {
                Aircraft = flight.Aircraft,
                AircraftId = flight.Aircraft.AircraftId
            };

            await _dbContext.AircraftCabins.AddAsync(aircraftCabin);
            await _dbContext.SaveChangesAsync();

            var numberOfZonesToCreate = _utilityService.DetermineCabinZonesCapacity(flight.SeatMap);
            await CreateZone(numberOfZonesToCreate, flight.Aircraft.Cabin);
        }

        public async Task CreateBaggageHoldAndCompartments(OutboundFlight outbound)
        {
            var baggageHold = new AircraftBaggageHold();
            outbound.Aircraft.BaggageHold = baggageHold;
            outbound.Aircraft.AircraftBaggageHoldId = baggageHold.BaggageHoldId;
            baggageHold.Aircraft = outbound.Aircraft;
            baggageHold.AircraftId = outbound.AircraftId;

           await _dbContext.AircraftBaggageHolds.AddAsync(baggageHold);
           await _dbContext.SaveChangesAsync();

            var numberOfCompartmentsToCreate = _utilityService.DetermineNumberOfHoldsToCreate(outbound.LoadingInstruction);
            await CreateCompartments(numberOfCompartmentsToCreate, outbound.Aircraft.BaggageHold);
        }

        private async Task CreateCompartments(List<int> compartmentPieces, AircraftBaggageHold baggageHold)
        {
            foreach (var pieces in compartmentPieces)
            {
                var newCompartment = new Compartment
                {
                    BaggageHold = baggageHold,
                    BaggageHoldId = baggageHold.BaggageHoldId,
                    PiecesToPutInCompartment = pieces,
                };

                baggageHold.Compartments.Add(newCompartment);

                await _dbContext.Compartments.AddAsync(newCompartment);
                await _dbContext.SaveChangesAsync();

            }
        }

        private async Task CreateZone(Dictionary<string,int> capacityPerZone, AircraftCabin cabin)
        {
            foreach (var zone in capacityPerZone)
            {
                var newZone = new AircraftCabinZone
                {
                    Cabin = cabin,
                    AircraftCabinId = cabin.Id,
                    ZoneType = zone.Key,
                    ZoneCapacity = zone.Value 

                };
                
                cabin.Zones.Add(newZone);

                await _dbContext.CabinZones.AddAsync(newZone);
                await _dbContext.SaveChangesAsync();
            }
        }
 
    }
}
