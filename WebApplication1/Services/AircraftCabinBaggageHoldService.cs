namespace BMS.Services
{
    using BMS.Data.Models;
    using BMS.Factories.Contracts;
    using BMS.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApplication1.Data;

    public class AircraftCabinBaggageHoldService : IAircraftCabinBaggageHoldService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IAircraftCabinFactory _cabinFactory;
        private readonly IAircraftBaggageHoldFactory _baggageHoldFactory;

        public AircraftCabinBaggageHoldService(ApplicationDbContext dbContext,IAircraftCabinFactory cabinFactory, IAircraftBaggageHoldFactory baggageHoldFactory)
        {
            _cabinFactory = cabinFactory;
            _baggageHoldFactory = baggageHoldFactory;
            _dbContext = dbContext;
        }

        public async Task AddCabinAndBaggageHoldToAircraft(Aircraft aircraft)
        {
            
        }
    }
}
