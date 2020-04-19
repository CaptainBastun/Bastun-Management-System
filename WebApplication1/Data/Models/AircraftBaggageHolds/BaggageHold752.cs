namespace BMS.Data.Models.AircraftBaggageHolds
{
    using BMS.GlobalData.BaggageHoldConstants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BaggageHold752 : AircraftBaggageHold
    {
        public BaggageHold752()
        {
            SetHoldData();
        }

        protected override void SetHoldData()
        {
            this.CompartmentOneCapacity = HoldConstants752.HoldOneCapacity;
            this.CompartmentTwoCapacity = HoldConstants752.HoldTwoCapacity;
            this.CompartmentThreeCapacity = HoldConstants752.HoldThreeCapacity;
            this.CompartmentFourCapacity = HoldConstants752.HoldFourCapacity;
            this.CompartmentFiveCapacity = HoldConstants752.HoldFiveCapacity;
        }
    }
}
