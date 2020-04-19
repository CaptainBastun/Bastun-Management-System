namespace BMS.Data.Models.AircraftBaggageHolds
{
    using BMS.GlobalData.BaggageHoldConstants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BaggageHold763 : AircraftBaggageHold
    {
        public BaggageHold763()
        {
            SetHoldData();
        }
        protected override void SetHoldData()
        {
            CompartmentOneCapacity = HoldConstants763.HoldOneCapacity;
            CompartmentTwoCapacity = HoldConstants763.HoldTwoCapacity;
            CompartmentThreeCapacity = HoldConstants763.HoldThreeCapacity;
            CompartmentFourCapacity = HoldConstants763.HoldFourCapacity;
            CompartmentFiveCapacity = HoldConstants763.HoldFiveCapacity;
        }
    }
}
