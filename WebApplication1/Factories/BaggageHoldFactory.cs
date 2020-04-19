namespace BMS.Factories
{
    using BMS.Data.Models;
    using BMS.Data.Models.AircraftBaggageHolds;
    using BMS.Factories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BaggageHoldFactory : IAircraftBaggageHoldFactory
    {
        public AircraftBaggageHold CreateBaggageHold(string aircraftType)
        {
            switch (aircraftType)
            {
                case "A320":
                    return new BaggageHoldA320();
                case "B738":
                    return new BaggageHold738();
                case "B752":
                    return new BaggageHold752();
                case "B763":
                    return new BaggageHold763();
                case "B788":
                    return new BaggageHold788();
                default:
                    return null;
            }
        }
    }
}
