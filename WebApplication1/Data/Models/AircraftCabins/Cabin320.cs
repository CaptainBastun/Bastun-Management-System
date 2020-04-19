namespace BMS.Data.Models.AircraftCabins
{
    using BMS.GlobalData.CabinConstants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class Cabin320 : AircraftCabin
    {
        public Cabin320()
        {
            SetCabinData();
        }

        protected override void SetCabinData()
        {
            ZoneAlphaCapacity = CabinConstants320.ZoneAlphaCapacity;
            ZoneBravoCapacity = CabinConstants320.ZoneBravoCapacity;
            ZoneCharlieCapacity = CabinConstants320.ZoneCharlieCapacity;
        }
    }
}
