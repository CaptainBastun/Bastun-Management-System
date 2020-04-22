namespace BMS.Models.FlightInputModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using BMS.GlobalData.ErrorMessages;
    using BMS.GlobalData;

    public class OutboundFlightInputModel
    {
        [Required(ErrorMessage = InvalidErrorMessages.FlightNumberRequired)]
        [RegularExpression(FlightInputDataValidation.GeneralFlightNumberValidation, ErrorMessage = InvalidErrorMessages.FlightNumber)]
        public string FlightNumber { get; set; }

        [Required(ErrorMessage = InvalidErrorMessages.HandlingStationIsRequired)]
        [RegularExpression(FlightInputDataValidation.StationValidation, ErrorMessage = InvalidErrorMessages.HandlingStationIsInvalid)]
        public string HandlingStation { get; set; }

        [Required(ErrorMessage = InvalidErrorMessages.DestinationRequired)]
        [RegularExpression(FlightInputDataValidation.StationValidation, ErrorMessage = InvalidErrorMessages.Destination)]
        public string Destination { get; set; }

        [Required(ErrorMessage = InvalidErrorMessages.FlightSTDIsRequired)]
        public DateTime STD { get; set; }

        [Required(ErrorMessage = InvalidErrorMessages.BookedPAXRequired)]
        [Range(1, 221, ErrorMessage = InvalidErrorMessages.BookedPax)]
        public int BookedPax { get; set; }

        [Required(ErrorMessage = InvalidErrorMessages.SeatMapRequired)]
        [RegularExpression(FlightInputDataValidation.SeatMapValidation, ErrorMessage = InvalidErrorMessages.SeatMapIsInvalid)]
        public string SeatMap { get; set; }

        [Required(ErrorMessage = InvalidErrorMessages.RampAgentNameRequired)]
        public string RampAgentName { get; set; }
    }
}
