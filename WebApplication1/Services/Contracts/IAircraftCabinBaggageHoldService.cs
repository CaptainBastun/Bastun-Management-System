namespace BMS.Services.Contracts
{
    using BMS.Data.Models;
    using System.Threading.Tasks;

    public interface IAircraftCabinBaggageHoldService
    {
        Task AddCabinAndBaggageHoldToAircraft(Aircraft aircraft);
    }
}
