namespace BMS.Data.Models.AircraftBaggageHolds
{
    using BMS.GlobalData.BaggageHoldConstants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BaggageHold788 : AircraftBaggageHold
    {
        public BaggageHold788()
        {
            SetHoldData();
        }
        
        protected override void SetHoldData()
        {
           CompartmentOneCapacity = HoldConstants788.HoldOneCapacity;
           CompartmentTwoCapacity = HoldConstants788.HoldTwoCapacity;
           CompartmentThreeCapacity = HoldConstants788.HoldThreeCapacity;
           CompartmentFourCapacity = HoldConstants788.HoldFourCapacity;
           CompartmentFiveCapacity = HoldConstants788.HoldFiveCapacity;
        }
    }
}
