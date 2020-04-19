namespace BMS.Data.Models.AircraftCabins
{
    using BMS.GlobalData.CabinConstants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class Cabin752 : AircraftCabin
    {
        public Cabin752()
        {
            SetCabinData();
        }

        protected override void SetCabinData()
        {
            ZoneAlphaCapacity = CabinConstants752.ZoneAplhaCapacity;
            ZoneBravoCapacity = CabinConstants752.ZoneBravoCapacity;
            ZoneCharlieCapacity = CabinConstants752.ZoneCharlieCapacity;
        }
    }
}
