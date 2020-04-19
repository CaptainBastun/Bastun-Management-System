namespace BMS.Services
{
    using AutoMapper;
    using BMS.Data.DTO.MovementsDTO;
    using BMS.Data.Models;
    using BMS.Data.Models.Contracts.FlightContracts;
    using BMS.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            newArrivalMovement.InboundFlightId = inbound.FlightId;

            _dbContext.ArrivalMovements.Add(newArrivalMovement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateDepartureMovement(DepartureMovementDTO movementDTO,OutboundFlight outbound)
        {
            var newDepartureMovement = _mapper.Map<DepartureMovement>(movementDTO);

            newDepartureMovement.OutboundFlight = outbound;
            newDepartureMovement.OutboundFlightId = outbound.FlightId;

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
