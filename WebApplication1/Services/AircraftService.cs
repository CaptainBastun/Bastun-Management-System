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
        private readonly IAircraftCabinService _cabinService;
        private readonly IAircraftBaggageHoldService _baggageHoldService;

        public AircraftService(ApplicationDbContext dbContext,IFlightService flightsService, IAircraftCabinService cabinService, IAircraftBaggageHoldService baggageHoldService)
        {
            _dbContext = dbContext;
            _flightsService = flightsService;
            _cabinService = cabinService;
            _baggageHoldService = baggageHoldService;
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

            if (outboundFlightToRegisterAircraftTo != null)
            {
                var newAircraft = new Aircraft
                {
                    AircraftRegistration = aircraftInputModel.AircraftRegistration,
                    Version = aircraftInputModel.Version,
                    Type = aircraftInputModel.Type,
                    OutboundFlightId = outboundFlightToRegisterAircraftTo.FlightId,
                };

                newAircraft.IsAicraftContainerized = this.IsAircraftGoingToBeContainerized(newAircraft.Type.ToString());
                this._dbContext.Aircraft.Add(newAircraft);
                this._dbContext.SaveChanges();

                this.AddCabinAndBaggageHoldToAircraft(aircraftInputModel.AircraftRegistration);
            }
        }


        public Aircraft GetAicraftByRegistration(string registration)
        {
            return _dbContext.Aircraft.FirstOrDefault(ac => ac.AircraftRegistration == registration);
        }

       
        private void AddCabinAndBaggageHoldToAircraft(string registration)
        {
            var aircraft = this.GetAicraftByRegistration(registration);

            var cabin  = this._cabinService.AddCabinToAircraft(aircraft);
            var baggageHold = this._baggageHoldService.AddBaggageHoldToAircraft(aircraft);

            aircraft.Cabin = cabin;
            aircraft.BaggageHold = baggageHold;
            this._dbContext.SaveChanges();
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
