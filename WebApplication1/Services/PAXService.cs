namespace BMS.Services
{
    using AutoMapper;
    using BMS.Data.Models;
    using BMS.Data.Models.Cabins;
    using BMS.Data.Models.Enums;
    using BMS.GlobalData.PAXConstants.PAXErrorMessages;
    using BMS.Models;
    using BMS.Models.ViewModels.Passengers;
    using BMS.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;
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

            string passengerWeight = DeterminePassengerWeight(passenger.Gender.ToString());
            passenger.Weight = (PAXWeight)Enum.Parse(typeof(PAXWeight), passengerWeight);

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

        private string DeterminePassengerWeight(string gender)
        {
            switch (gender)
            {
                case "M":
                    return "88";
                case "F":
                    return "70";
                case "C":
                    return "35";
                case "i":
                    return "0";
                default:
                    return "0";
            }
        }

        public PassengerViewModel GetAllPassengers(string flightNumber)
        {

            var allPassengers =
                _dbContext
                .OutboundFlights
                .AsEnumerable()
                .Where(x => x.FlightNumber == flightNumber)
                .Select(z => z.Aircraft.Cabin)
                .SelectMany(c => 
                    c
                    .Zones
                    .SelectMany(p => 
                        p
                        .Passengers
                        .Select(q => new PassengerDetailsViewModel { 
                            FirstName = q.FirstName,
                            LastName = q.LastName,
                            Gender = q.Gender.ToString(),
                            Nationality = q.Nationality,
                            Destination = c.Aircraft.OutboundFlight.Destination 
                     
                }))
                .ToList())
                .OrderBy(g => g.FirstName)
                .ToList();

            if (allPassengers.Count == 0)
            {
                throw new Exception("No passengers found for flight");
            }


            var passengerViewModel = new PassengerViewModel()
            {
                Passengers = allPassengers
            };

            return passengerViewModel;
        }

        public async Task<PassengerOffloadEditViewModel> GetPassengerByFullName(string passengerFullName)
        {
            string[] passengerNames =
                passengerFullName
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var passengerByFullName =
                await
                _dbContext
                .Passengers
                .Where(x => x.FirstName == passengerNames[0] && x.LastName == passengerNames[1])
                .FirstOrDefaultAsync();

            if (passengerByFullName == null)
            {
                throw new Exception(PassengerErrors.PassengerNotFound);
            }

            var viewModel = _mapper.Map<PassengerOffloadEditViewModel>(passengerByFullName);

            return viewModel;
        }

        public async Task<Passenger> GetPassengerById(int id)
        {
            if (id == 0 || id < 0)
            {
                throw new Exception("No such passenger found");
            }

            return await _dbContext.Passengers.FirstOrDefaultAsync(x => x.PaxId == id);
        }
    }
}
