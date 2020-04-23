using BMS.GlobalData.ErrorMessages;
using BMS.GlobalData.PAXConstants;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class PAXSuitcaseInputModel
    {
        [Required(ErrorMessage = InvalidPAXErrorMessages.PaxFullNameRequired)]
        [RegularExpression(PAXInputValidation.PaxFullNameValidation, ErrorMessage = InvalidPAXErrorMessages.PaxFullNameInvalid)]
        public string FullName { get; set; }

        [Required(ErrorMessage = InvalidPAXErrorMessages.SuitcaseWeightInvalid)]
        [Range(PAXSuitcaseWeightConstants.SuitcaseMinWeight, PAXSuitcaseWeightConstants.SuitcaseMaxWeight, ErrorMessage = "Suitcase weight is invalid!")]
        public int Weight { get; set; }
    }
}
