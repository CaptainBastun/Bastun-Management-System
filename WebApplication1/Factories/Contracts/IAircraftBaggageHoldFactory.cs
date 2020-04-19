namespace BMS.Factories.Contracts
{
    using BMS.Data.Models;

    public interface IAircraftBaggageHoldFactory
    {
        AircraftBaggageHold CreateBaggageHold(string aircraftType);
    }
}
