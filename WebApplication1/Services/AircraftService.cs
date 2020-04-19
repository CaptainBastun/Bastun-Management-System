namespace BMS.Services
{
    using BMS.Data.Models;
    using BMS.Models;
    using BMS.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApplication1.Data;

    public class AircraftService : IAircraftService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFlightService _flightsService;
        private readonly IAircraftCabinBaggageHoldService _cabinBaggageHoldService;

        public AircraftService(ApplicationDbContext dbContext,IFlightService flightsService,IAircraftCabinBaggageHoldService cabinBaggageHoldService)
        {
            _dbContext = dbContext;
            _flightsService = flightsService;
            _cabinBaggageHoldService = cabinBaggageHoldService;
        }

        public bool CheckAircraftRegistration(string registration)
        {
            return _dbContext.Aircraft.Any(x => x.AircraftRegistration == registration);
        }

        public bool IsAircraftGoingToBeContainerized(string aircraftType)
        {
            return aircraftType == "B763" || aircraftType == "B788";
        }

        public async Task RegisterAircraft(AircraftInputModel aircraftInputModel)
        {
            var outboundFlightToRegisterAircraftTo = await _flightsService.GetOutboundFlightByFlightNumber(aircraftInputModel.FlightNumber);
            bool isContainerized = IsAircraftGoingToBeContainerized(aircraftInputModel.Type.ToString());
     
        }

        public Aircraft GetAicraftByRegistration(string registration)
        {
            return _dbContext.Aircraft.FirstOrDefault(ac => ac.AircraftRegistration == registration);
        }

        private async Task AddCabinToAircraft(string registration)
        {
            var aircraft = GetAicraftByRegistration(registration);

            await _cabinBaggageHoldService.AddCabinAndBaggageHoldToAircraft(aircraft);

            await _dbContext.SaveChangesAsync();
        }

        public string IsAircraftOfACertainType(OutboundFlight flight)
        {
            string type = string.Empty;
            if (flight.Aircraft.Type.ToString() == "B763" || flight.Aircraft.Type.ToString() == "B788")
            {
                type =  flight.Aircraft.Type.ToString();
            }
            return type;
        }
    }
}
