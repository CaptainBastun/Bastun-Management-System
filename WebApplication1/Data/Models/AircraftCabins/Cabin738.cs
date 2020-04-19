namespace BMS.Data.Models.AircraftCabins
{
    using BMS.GlobalData.CabinConstants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Cabin738 : AircraftCabin
    {
        public Cabin738()
        {
            SetCabinData();
        }

        protected override void SetCabinData()
        {
            ZoneAlphaCapacity = CabinConstants738.ZoneAlphaCapacity;
            ZoneBravoCapacity = CabinConstants738.ZoneBravoCapacity;
            ZoneCharlieCapacity = CabinConstants738.ZoneCharlieCapacity;
            ZoneDeltaCapacity = CabinConstants738.ZoneDeltaCapacity;
        }
    }
}
