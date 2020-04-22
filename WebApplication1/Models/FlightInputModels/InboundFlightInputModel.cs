namespace BMS.Models.FlightInputModels
{
    using BMS.GlobalData;
    using BMS.GlobalData.ErrorMessages;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class InboundFlightInputModel
    {
        [Required(ErrorMessage = InvalidErrorMessages.FlightNumberRequired)]
        [RegularExpression(FlightInputDataValidation.GeneralFlightNumberValidation, ErrorMessage = InvalidErrorMessages.FlightNumber)]
        public string FlightNumber { get; set; }

        [Required(ErrorMessage = InvalidErrorMessages.OriginRequired)]
        [RegularExpression(FlightInputDataValidation.StationValidation, ErrorMessage = InvalidErrorMessages.Origin)]
        public string Origin { get; set; }


        [Required(ErrorMessage = InvalidErrorMessages.FlightSTAIsRequired)]
        public DateTime STA { get; set; }
    }
}
