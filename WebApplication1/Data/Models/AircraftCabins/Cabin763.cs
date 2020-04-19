namespace BMS.Data.Models.AircraftCabins
{
    using BMS.GlobalData.CabinConstants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Cabin763 : AircraftCabin
    {
        public Cabin763()
        {
            SetCabinData();
        }

        protected override void SetCabinData()
        {
            ZoneAlphaCapacity = CabinConstants763.ZoneAlphaCapacity;
            ZoneBravoCapacity = CabinConstants763.ZoneBravoCapacity;
            ZoneCharlieCapacity = CabinConstants763.ZoneCharlieCapacity;
        }
    }
}
