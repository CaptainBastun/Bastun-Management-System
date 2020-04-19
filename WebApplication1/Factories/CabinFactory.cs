namespace BMS.Factories
{
    using BMS.Data.Models;
    using BMS.Data.Models.AircraftCabins;
    using BMS.Factories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CabinFactory : IAircraftCabinFactory
    {
        public AircraftCabin CreateCabin(string aircraftType)
        {
            switch (aircraftType)
            {
                case "A320":
                    return new Cabin320();
                case "B738":
                    return new Cabin738();
                case "B752":
                    return new Cabin752();
                case "B763":
                    return new Cabin763();
                case "B788":
                    return new Cabin788();
                default:
                    return null;
                   
            }
        }
    }
}
