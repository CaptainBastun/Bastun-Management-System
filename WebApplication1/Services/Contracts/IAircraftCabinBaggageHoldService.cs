namespace BMS.Services.Contracts
{
    using BMS.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAircraftCabinBaggageHoldService
    {
        Task<bool> CreateCabinAndZones(OutboundFlight flight);

        Task<bool> CreateBaggageHoldAndCompartments(OutboundFlight flight);


    }
}
