namespace BMS.Services
{
    using AutoMapper;
    using BMS.Data.Models;
    using BMS.Models;
    using BMS.Services.Contracts;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApplication1.Data;

    public class AircraftService : IAircraftService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFlightService _flightsService;
        private readonly IAircraftCabinBaggageHoldService _cabinBaggageHoldService;
        private readonly IMapper _mapper;

        public AircraftService(ApplicationDbContext dbContext,IFlightService flightsService,
            IAircraftCabinBaggageHoldService cabinBaggageHoldService, IMapper mapper)
        {
            _dbContext = dbContext;
            _flightsService = flightsService;
            _cabinBaggageHoldService = cabinBaggageHoldService;
            _mapper = mapper;
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

            var aircraft = _mapper.Map<Aircraft>(aircraftInputModel);
            aircraft.OutboundFlight = outboundFlightToRegisterAircraftTo;
            aircraft.OutboundFlightFlightNumber = outboundFlightToRegisterAircraftTo.FlightNumber;

            await _dbContext.Aircraft.AddAsync(aircraft);
            await _dbContext.SaveChangesAsync();
            
        }

        public Aircraft GetAicraftByRegistration(string registration)
        {
            return _dbContext.Aircraft.FirstOrDefault(ac => ac.AircraftRegistration == registration);
        }

    }
}
