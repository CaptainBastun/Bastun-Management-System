namespace BMS.Data.Models.AircraftBaggageHolds
{
    using BMS.GlobalData.CabinConstants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class BaggageHold738 : AircraftBaggageHold
    {
        public BaggageHold738()
        {
            SetHoldData();
        }
        protected override void SetHoldData()
        {
            this.CompartmentOneCapacity = HoldConstants738.CompartmentOneCapacity;
            this.CompartmentTwoCapacity = HoldConstants738.CompartmentTwoCapacity;
            this.CompartmentThreeCapacity = HoldConstants738.CompartmentThreeCapacity;
            this.CompartmentFourCapacity = HoldConstants738.CompartmentFourCapacity;

        }
    }
}
