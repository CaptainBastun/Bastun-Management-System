using System.Collections.Generic;

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
    using System.Reflection;
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

            if (currentZoneType == null)
            {
                throw  new NullReferenceException("No such seat found in aircraft");
            }

            string passengerWeight = DeterminePassengerWeight(passenger.Gender.ToString());
            passenger.Weight = (PAXWeight)Enum.Parse(typeof(PAXWeight), passengerWeight);

            var test =
                outboundFlight
                    .Aircraft
                    .Cabin
                    .Zones
                    .Select(x => x)
                    .ToList();

         

            var currentZone =
                outboundFlight
                    .Aircraft
                    .Cabin
                    .Zones
                    .FirstOrDefault(z => z.ZoneType == currentZoneType);

             

            if (currentZone == null)
            {
                throw  new NullReferenceException("No such seat found in aircraft");
            }

            if (currentZone.IsZoneFull())
            {
                currentZone =
                    outboundFlight
                        .Aircraft
                        .Cabin
                        .Zones
                        .FirstOrDefault(z => !z.IsZoneFull());

            }

            if (currentZone == null)
            {
                throw  new NullReferenceException("Aircraft is already full!");
            }

            currentZone.AddPassenger(passenger);

            await _dbContext.Passengers.AddAsync(passenger);
            await _dbContext.SaveChangesAsync();

        }

        private int GetPassengerRow(string passengerSeat)
        {
            return int.Parse(passengerSeat.Remove(passengerSeat.Length-1, 1));
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

            if (passengerRow > 30 && passengerRow <= 32)
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

        public async Task OffloadPassenger(int id)
        {
            _dbContext.Passengers.Remove(await GetPassengerById(id));
        }

        public async Task EditPassengerData(PassengerOffloadEditInputModel passenger,int id)
        {
            var passengerToEdit = await GetPassengerById(id);

            if (passenger == null || id <= 0)
            {
                throw  new ArgumentException("Invalid data entered");
            }

            var allValuesToSetNames =
                passenger
                    .GetType()
                    .GetProperties();

            var propertiesToChange = new Dictionary<string, object>();

            foreach (var valueWillSet in allValuesToSetNames)
            {
                var value =
                    passenger.GetType()
                        .GetProperty(valueWillSet.Name)
                        .GetValue(passenger, null);

                if (value != null || (int)value != 0)
                {
                    propertiesToChange.Add(valueWillSet.Name, value);
                }
            }

            var passengerProperties =
                passengerToEdit
                    .GetType()
                    .GetProperties();
            var passengerType = typeof(Passenger);
            foreach (var property in passengerProperties)
            {
                string propertyName = property.Name;

                if (propertiesToChange.ContainsKey(propertyName))
                {
                    var currentPassengerProperty = passengerType.GetProperty(propertyName);

                    if (propertyName == "Gender")
                    {
                        var genderFromDictionary = propertiesToChange[propertyName];
                        var parsedGender = (Gender)Enum.Parse(typeof(Gender), genderFromDictionary.ToString());
                        currentPassengerProperty.SetValue(passengerToEdit,parsedGender);
                        continue;
                    }

                    currentPassengerProperty.SetValue(passengerToEdit, propertiesToChange[propertyName]);
                }
            }

            await _dbContext.SaveChangesAsync();

        }
    }
}
