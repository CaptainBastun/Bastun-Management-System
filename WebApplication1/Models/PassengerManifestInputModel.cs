namespace BMS.Models
{
    using BMS.GlobalData;
    using BMS.GlobalData.ErrorMessages;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class PassengerManifestInputModel
    {
        [Required(ErrorMessage = InvalidErrorMessages.FlightNumberRequired)]
        [RegularExpression(FlightInputDataValidation.GeneralFlightNumberValidation, ErrorMessage = InvalidErrorMessages.InvalidFlightNumberFormat)]
        public string FlightNumber { get; set; }
    }
}
