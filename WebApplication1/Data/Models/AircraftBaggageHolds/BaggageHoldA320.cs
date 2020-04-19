using BMS.GlobalData.BaggageHoldConstants;

namespace BMS.Data.Models.AircraftBaggageHolds
{
    

    public class BaggageHoldA320 : AircraftBaggageHold
    {
        public BaggageHoldA320()
        {
            SetHoldData();
        }

        protected override void SetHoldData()
        {
            CompartmentOneCapacity = HoldConstants320.HoldOneCapacity;
            CompartmentTwoCapacity = HoldConstants320.HoldTwoCapacity;
            CompartmentThreeCapacity = HoldConstants320.HoldThreeCapacity;
            CompartmentFourCapacity = HoldConstants320.HoldFourCapacity;
            CompartmentFiveCapacity = HoldConstants320.HoldFiveCapacity;
        }
    }
}
