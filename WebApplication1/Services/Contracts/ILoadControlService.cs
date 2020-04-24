namespace BMS.Services.Contracts
{
    using BMS.Data.Models;
    using BMS.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface ILoadControlService
    {
        Task<int> CalculateTotalPaxWeight(string flightNumber);


        Task AddLoadingInstruction(OutboundFlight flight,BulkLoadingInstructionInputModel loadingInstructionInputModel);
    }
}
