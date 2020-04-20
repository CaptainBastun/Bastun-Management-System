namespace BMS.Services
{
    using BMS.Models;
    using BMS.Services.Contracts;
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApplication1.Data;
    using BMS.Data.Models;
    using BMS.Data.Models.Contracts;
    using Microsoft.EntityFrameworkCore;
    using BMS.Models.ViewModels.Flights;

    public class FlightsService : IFlightService
    {
        private readonly ApplicationDbContext _DbContext;
        private readonly IMapper _mapper;

        public FlightsService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _mapper = mapper;
        }



        public bool CheckIfFlightIsInbound(string flightNumber)
        {
            return _DbContext.InboundFlights.Any(x => x.FlightNumber == flightNumber);
        }

        public bool CheckIfFlightIsOutbound(string flightNumber)
        {
            return _DbContext.OutboundFlights.Any(x => x.FlightNumber == flightNumber);
        }

        public DisplayDailyFlightViewModel GetAllFlights()
        {
            var outboundFlightViewModels =
                _DbContext
                .OutboundFlights
                .Select(x => new FlightViewModel
                {
                    AircraftType = x.Aircraft.Type.ToString(),
                    Destination = x.Destination,
                    Registration = x.Aircraft.AircraftRegistration,
                    FlightNumber = x.FlightNumber,
                    STD = x.STD.Hour.ToString(),
                    RampAgent = x.RampAgentName,
                })
                .ToList();

            foreach (var flightViewModel in outboundFlightViewModels)
            {
                var inboundFlight =
                    _DbContext
                    .InboundFlights
                    .FirstOrDefault(x => x.RampAgentName == flightViewModel.RampAgent);

                flightViewModel.STA = inboundFlight.STA.Hour.ToString();
                flightViewModel.Origin = inboundFlight.Origin;
            }


            var dailyFlightsModel = new DisplayDailyFlightViewModel(outboundFlightViewModels);
            return dailyFlightsModel;
        }

        public async Task<InboundFlight> GetInboundFlightByFlightNumber(string inboundFlightNumber)
        {
            return await _DbContext.InboundFlights.FirstOrDefaultAsync(x => x.FlightNumber == inboundFlightNumber);
        }

        public async Task<OutboundFlight> GetOutboundFlightByFlightNumber(string outboundFlightNumber)
        {
            return await _DbContext.OutboundFlights.FirstOrDefaultAsync(obF => obF.FlightNumber == outboundFlightNumber);
        }

        public async Task CreateFlights(FlightInputModel flightInputModel)
        {
            string[] splitFlightNumbers =
                flightInputModel
                .FlightNumber
                .Split("/", StringSplitOptions.RemoveEmptyEntries);

            string inboundFlightNumber = splitFlightNumbers[0];
            string outboundFlightNumber = splitFlightNumbers[1];

            var newInboundFlight = _mapper.Map<InboundFlight>(flightInputModel);
            var newOutboundFlight = _mapper.Map<OutboundFlight>(flightInputModel);

            newInboundFlight.FlightNumber = inboundFlightNumber;
            newOutboundFlight.FlightNumber = outboundFlightNumber;
     
            _DbContext.InboundFlights.Add(newInboundFlight);
            _DbContext.OutboundFlights.Add(newOutboundFlight);
            await _DbContext.SaveChangesAsync();
        }

    } 
}
