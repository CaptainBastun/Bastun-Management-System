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

        Task<IEnumerable<Passenger>> GetPassengersByZoneAlpha(string flightNumber);

        Task<IEnumerable<Passenger>> GetPassengersByZoneBravo(string flightNumber);

        Task<IEnumerable<Passenger>> GetPassengersByZoneCharlie(string flightNumber);

        Task<IEnumerable<Passenger>> GetPassengersByZoneDelta(string flightNumber);


        Task AddLoadingInstruction(OutboundFlight flight,BulkLoadingInstructionInputModel loadingInstructionInputModel);
    }
}
