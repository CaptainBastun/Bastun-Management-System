namespace BMS.Services
{
    using AutoMapper;
    using BMS.Data.DTO.MovementsDTO;
    using BMS.Data.Models;
    using BMS.Services.Contracts;
    using System.Threading.Tasks;
    using WebApplication1.Data;

    public class MovementsService : IMovementService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;

        public MovementsService(ApplicationDbContext dbContext, IFlightService flightService, IMapper mapper)
        {
            _dbContext = dbContext;
            _flightService = flightService;
            _mapper = mapper;
        }

        public async Task CreateArrivalMovement(ArrivalMovementDTO movementDTO,InboundFlight inbound)
        {
            var newArrivalMovement = _mapper.Map<ArrivalMovement>(movementDTO);

            newArrivalMovement.InboundFlight = inbound;
            newArrivalMovement.InboundFlightFlightNumber = inbound.FlightNumber;

            inbound.ArrivalMovement = newArrivalMovement;
            inbound.ArrivalMovementId = newArrivalMovement.Id;

            await _dbContext.ArrivalMovements.AddAsync(newArrivalMovement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateDepartureMovement(DepartureMovementDTO movementDTO,OutboundFlight outbound)
        {
            var newDepartureMovement = _mapper.Map<DepartureMovement>(movementDTO);

            newDepartureMovement.OutboundFlight = outbound;
            newDepartureMovement.OutboundFlightFlightNumber = outbound.FlightNumber;

            _dbContext.DepartureMovements.Add(newDepartureMovement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ArrivalMovement> GetArrivalMovementByFlightNumber(string flightNumber)
        {
            var inboundFlight = await this._flightService.GetInboundFlightByFlightNumber(flightNumber);
            return inboundFlight.ArrivalMovement;
        }

        public async Task<DepartureMovement> GetDepartureMovementByFlightNumber(string flightNumber)
        {
            var outboundFlight = await _flightService.GetOutboundFlightByFlightNumber(flightNumber);
            return outboundFlight.DepartureMovement;
        }
    }
}
