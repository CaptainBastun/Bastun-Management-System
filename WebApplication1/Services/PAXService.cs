namespace BMS.Services
{
    using AutoMapper;
    using BMS.Data.Models;
    using BMS.Data.Models.Cabins;
    using BMS.Models;
    using BMS.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApplication1.Data;

    public class PAXService : IPAXService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;

        public PAXService(ApplicationDbContext dbContext,IFlightService flightService, IMapper mapper)
        {
            _dbContext = dbContext;
            _flightService = flightService;
            _mapper = mapper;
        }

        public async Task CreatePassenger(PAXInputModel inputModel)
        {
            var outboundFlight = await _flightService.GetOutboundFlightByFlightNumber(inputModel.FlightNumber);

            var passenger = _mapper.Map<Passenger>(inputModel);

            int passengerRow = GetPassengerRow(inputModel.SeatNumber);
            string currentZoneType = DetermineZoneType(passengerRow);

            var zone =
                outboundFlight
                .Aircraft
                .Cabin
                .Zones
                .FirstOrDefault(x => !x.IsZoneFull() && x.ZoneType == currentZoneType);

            zone.AddPassenger(passenger);
     
            await _dbContext.Passengers.AddAsync(passenger);
            await _dbContext.SaveChangesAsync();

        }

        private int GetPassengerRow(string passengerseat)
        {
            return int.Parse(passengerseat.Remove(passengerseat.Length-1, 1));
        }

        private string DetermineZoneType(int passengerRow)
        {
            if (passengerRow >= 1 && passengerRow <= 10)
            {
                return "A";
            }

            if (passengerRow > 10 && passengerRow <= 20)
            {
                return "B";
            }

            if (passengerRow > 20 && passengerRow <= 30)
            {
                return "C";
            }

            if (passengerRow > 30 || passengerRow <= 32)
            {
                return "D";
            }

            return null;
        }

       
    }
}
