using System.Runtime.InteropServices;

namespace BMS.Services
{
    using AutoMapper;
    using BMS.Data.LoadingInstructions;
    using BMS.Data.Models;
    using BMS.Models;
    using BMS.Services.Contracts;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApplication1.Data;

    public class LoadControlService : ILoadControlService
    {
        private readonly IFlightService _flightsService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public LoadControlService(ApplicationDbContext dbContext,
            IFlightService flightService, IMapper mapper)
        {
            _flightsService = flightService;
            _mapper = mapper;
            _dbContext = dbContext;
        }


        public async Task<int> CalculateTotalPaxWeight(string flightNumber)
        {
            if (string.IsNullOrWhiteSpace(flightNumber) || string.IsNullOrEmpty(flightNumber))
            {
                throw  new ArgumentException("Input data is invalid");
            }

            var allPaxWeightsByGender = new List<int>();

            var flight = await _flightsService.GetOutboundFlightByFlightNumber(flightNumber);

            string[] genders = new string[]
            {
                "M",
                "F",
                "C",
            };

            for (int i = 0; i < genders.Length; i++)
            {
                string currentGender = genders[i];

                var allPassengersByGender =
                    flight
                        .Aircraft
                        .Cabin
                        .Zones
                        .SelectMany(p => p.Passengers
                            .Where(g => g.Gender.ToString() == currentGender));

                int totalWeightForCurrentGender =
                    allPassengersByGender
                        .Sum(w => (int) w.Weight);

                allPaxWeightsByGender.Add(totalWeightForCurrentGender);
            }

            return allPaxWeightsByGender.Sum();
        }

        public async Task<IEnumerable<Passenger>> GetPassengersByZoneAlpha(string flightNumber)
        {
            if (string.IsNullOrWhiteSpace(flightNumber) || string.IsNullOrEmpty(flightNumber))
            {
                throw  new ArgumentException("Input data is invalid");
            }

            var flight = await _flightsService.GetOutboundFlightByFlightNumber(flightNumber);

            var allPassengers =
                flight
                    .Aircraft
                    .Cabin
                    .Zones
                    .Where(z => z.ZoneType == "A")
                    .SelectMany(p => p.Passengers)
                    .ToList();

            return allPassengers;
        }

        public async Task<IEnumerable<Passenger>> GetPassengersByZoneBravo(string flightNumber)
        {
            if (string.IsNullOrWhiteSpace(flightNumber) || string.IsNullOrEmpty(flightNumber))
            {
                throw  new ArgumentException("Input data is invalid");
            }

            var flight = await _flightsService.GetOutboundFlightByFlightNumber(flightNumber);

            var allPassengersFromZoneBravo =
                flight
                    .Aircraft
                    .Cabin
                    .Zones
                    .Where(z => z.ZoneType == "B")
                    .SelectMany(p => p.Passengers)
                    .ToList();

            return allPassengersFromZoneBravo;

        }

        public async Task<IEnumerable<Passenger>> GetPassengersByZoneCharlie(string flightNumber)
        {
            if (string.IsNullOrWhiteSpace(flightNumber) || string.IsNullOrEmpty(flightNumber))
            {
                throw new ArgumentException("Input data is invalid");
            }

            var flight = await _flightsService.GetOutboundFlightByFlightNumber(flightNumber);

            var allPassengers =
                flight
                    .Aircraft
                    .Cabin
                    .Zones
                    .Where(z => z.ZoneType == "C")
                    .SelectMany(p => p.Passengers)
                    .ToList();

            return allPassengers;

        }

        public async Task<IEnumerable<Passenger>> GetPassengersByZoneDelta(string flightNumber)
        {
            if (string.IsNullOrEmpty(flightNumber) || string.IsNullOrWhiteSpace(flightNumber))
            {
                throw  new ArgumentException("Input data is invalid");
            }

            var outboundFlight = await _flightsService.GetOutboundFlightByFlightNumber(flightNumber);

            var allPassengersFromZoneDelta =
                outboundFlight
                    .Aircraft
                    .Cabin
                    .Zones
                    .Where(x => x.ZoneType == "A")
                    .SelectMany(p => p.Passengers)
                    .ToList();

            return allPassengersFromZoneDelta;
        }

        public async Task AddLoadingInstruction(OutboundFlight flight, BulkLoadingInstructionInputModel inputModel)
        {
            if (flight == null || inputModel == null)
            {
                throw  new ArgumentException("Data is invalid!");
            }

            var newLoadingInstruction = _mapper.Map<LoadingInstruction>(inputModel);

            flight.LoadingInstruction = newLoadingInstruction;
            flight.LoadingInstructionId = newLoadingInstruction.Id;
            newLoadingInstruction.OutboundFlight = flight;
            newLoadingInstruction.OutboundFlightFlightNumber = flight.FlightNumber;

            await _dbContext.LoadingInstructions.AddAsync(newLoadingInstruction);
            await _dbContext.SaveChangesAsync();
        }

    }
}
