using BMS.GlobalData;
using BMS.GlobalData.ErrorMessages;
using BMS.GlobalData.PAXConstants;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class PAXSuitcaseInputModel
    {
        [Required(ErrorMessage = InvalidErrorMessages.FlightNumberRequired)]
        [RegularExpression(FlightInputDataValidation.GeneralFlightNumberValidation, ErrorMessage = InvalidErrorMessages.FlightNumber)]
        public string FlightNumber { get; set; }

        [Required(ErrorMessage = InvalidPAXErrorMessages.SuitcaseWeightInvalid)]
        [Range(PAXSuitcaseWeightConstants.SuitcaseMinWeight, PAXSuitcaseWeightConstants.SuitcaseMaxWeight, ErrorMessage = "Suitcase weight is invalid!")]
        public int Weight { get; set; }

       
    }
}
