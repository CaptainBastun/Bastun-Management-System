namespace BMS.GlobalData.CabinConstants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class HoldConstants738
    {
        //each hold constants class dictates the total weight ( in kilograms) that can be put in the plane
        //without it being overloaded

        public const int CompartmentOneCapacity = 900;

        public const int CompartmentTwoCapacity = 1800;

        public const int CompartmentThreeCapacity = 2800;

        public const int CompartmentFourCapacity = 1000;

        //no compartment four, as the 738 is a smaller plane and doesn't have a bulk hold ( aka compartment 5)
        //as is the case with the larger aircraft 

    }
}
