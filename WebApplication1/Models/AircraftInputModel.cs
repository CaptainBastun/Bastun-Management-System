﻿namespace BMS.Models
{
    using BMS.Data.Models.Enums;
    using BMS.GlobalData;
    using BMS.GlobalData.ErrorMessages;
    using System.ComponentModel.DataAnnotations;

    public class AircraftInputModel
    {

        [Required(ErrorMessage =InvalidErrorMessages.FlightNumberRequired)]
        [RegularExpression(FlightInputDataValidation.GeneralFlightNumberValidation, ErrorMessage = InvalidErrorMessages.FlightNumber)]
        public string FlightNumber { get; set; }


        [Required(ErrorMessage = InvalidErrorMessages.AircraftTypeIsRequired)]
        [RegularExpression(FlightInputDataValidation.AircraftTypeValidation, ErrorMessage = InvalidErrorMessages.AircraftType)]
        public AircraftType Type { get; set; }

        [Required]
        [RegularExpression(FlightInputDataValidation.AircraftRegistrationValidation, ErrorMessage = (InvalidErrorMessages.AircraftRegistration))]
        public string AircraftRegistration { get; set; }

        [Required]
        [RegularExpression(FlightInputDataValidation.AircraftVersionValidation, ErrorMessage = (InvalidErrorMessages.AircraftVersion))]
        public string Version { get; set; }


    }
}
