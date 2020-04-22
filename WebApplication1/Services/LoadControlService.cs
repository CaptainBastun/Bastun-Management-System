namespace BMS.Services
{
    using AutoMapper;
    using BMS.Data.LoadingInstructions;
    using BMS.Data.Models;
    using BMS.Models;
    using BMS.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        public async Task AddLoadingInstruction(OutboundFlight flight, BulkLoadingInstructionInputModel inputModel)
        {
            var newLoadingInstruction = _mapper.Map<LoadingInstruction>(inputModel);

            flight.LoadingInstruction = newLoadingInstruction;
            flight.LoadingInstructionId = newLoadingInstruction.Id;
            newLoadingInstruction.OutboundFlight = flight;
            newLoadingInstruction.OutboundFlightFlightNumber = flight.FlightNumber;

            await _dbContext.LoadingInstructions.AddAsync(newLoadingInstruction);
            await _dbContext.SaveChangesAsync();
        }

        public void CalculatePAXWeightByGender()
        {
            throw new NotImplementedException();
        }


        public void GetPassengersByZoneDistribution()
        {
            throw new NotImplementedException();
        }
    }
}
