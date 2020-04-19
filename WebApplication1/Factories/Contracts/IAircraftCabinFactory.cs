namespace BMS.Factories.Contracts
{
    using BMS.Data.Models;
    using BMS.Models;
    public interface IAircraftCabinFactory
    {
        AircraftCabin CreateCabin(string aircraftType);
    }
}
