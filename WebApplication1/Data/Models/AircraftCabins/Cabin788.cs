namespace BMS.Data.Models.AircraftCabins
{
    using BMS.GlobalData.CabinConstants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Cabin788 : AircraftCabin
    {
        public Cabin788()
        {
            SetCabinData();
        }

        protected override void SetCabinData()
        {
            ZoneAlphaCapacity = CabinConstants788.ZoneAlphaCapacity;
            ZoneBravoCapacity = CabinConstants788.ZoneBravoCapacity;
            ZoneCharlieCapacity = CabinConstants788.ZoneCharlieCapacity;
        }
    }
}
