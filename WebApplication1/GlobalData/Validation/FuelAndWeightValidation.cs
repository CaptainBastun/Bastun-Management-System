namespace BMS.GlobalData.Validation
{
    using BMS.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class FuelAndWeightValidation
    {

        public static bool IsWeightInputDataValid(WeightFormInputModel weightFormInput)
        {
            if (weightFormInput.MaximumLandingWeight <= 0 || weightFormInput.MaximumTakeoffWeight <= 0
                 || weightFormInput.MaximumZeroFuelWeight <= 0)
            {
                return false;
            }

            if (weightFormInput.FlightNumber == null)
            {
                return false;
            }

            return true;
        }

        public static bool IsFuelFormInputDataValid(FuelFormInputModel fuelFormInput)
        {
            if (fuelFormInput.DryOperatingIndex <= 0 || fuelFormInput.DryOperatingWeight <= 0)
            {
                return false;
            }

            if (fuelFormInput.BlockFuel <= 0 || fuelFormInput.TakeoffFuel <= 0 || fuelFormInput.TripFuel <= 0 
                  || fuelFormInput.TaxiFuel <= 0)
            {
                return false;
            }

            if (fuelFormInput.PilotInCommand == null || fuelFormInput.CrewConfiguration == null ||
                 fuelFormInput.FlightNumber == null)
            {
                return false;
            }


            return true;
        }
    }
}
