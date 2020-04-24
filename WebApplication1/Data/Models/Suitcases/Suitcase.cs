namespace BMS.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using BMS.GlobalData.ErrorMessages;
    using BMS.GlobalData.PAXConstants;
    using BMS.Data.Models.BaggageHolds.AircraftBaggageHolds;

    public class Suitcase
    {

        public Suitcase()
        {
           SuitcaseId = Guid.NewGuid().ToString();
        }

        [Key]
        public string SuitcaseId { get; set; }

        [Range(PAXSuitcaseWeightConstants.SuitcaseMinWeight, PAXSuitcaseWeightConstants.SuitcaseMaxWeight, ErrorMessage = InvalidErrorMessages.PAXSuitcaseWeightIsInvalid)]
        public int Weight { get; set; }


        public int CompartmentId { get; set; }

        public virtual Compartment Compartment { get; set; }
    }
}
