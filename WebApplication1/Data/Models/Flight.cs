﻿namespace BMS.Data.Models
{
    using BMS.Data.Models.Contracts;
    using BMS.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using BMS.GlobalData;
    using BMS.GlobalData.ErrorMessages;
    using BMS.Data.Models.Messages;

    public class Flight : IFlight
    {
        public int FlightId { get; set; }

        [Required(ErrorMessage = InvalidErrorMessages.FlightNumberRequired)]
        [RegularExpression(FlightInputDataValidation.FlightNumberValidation, ErrorMessage = InvalidErrorMessages.FlightNumber)]
        public string FlightNumber { get; set; }

        [Required(ErrorMessage =InvalidErrorMessages.AircraftTypeIsRequired)]
        [RegularExpression(FlightInputDataValidation.AircraftTypeValidation, ErrorMessage =InvalidErrorMessages.AircraftType)]
        public AircraftType ACType { get; set; }

        [Required]
        [RegularExpression(FlightInputDataValidation.AircraftRegistrationValidation,ErrorMessage =(InvalidErrorMessages.AircraftRegistration))]
        public string AircraftRegistration { get; set; }

        [Required]
        [RegularExpression(FlightInputDataValidation.AircraftVersionValidation, ErrorMessage = (InvalidErrorMessages.AircraftVersion))]
        public string Version{ get; set; }

        [Required]
        [StringLength(3,ErrorMessage = InvalidErrorMessages.Origin)]
        public string Origin { get; set; }

        [Required]
        [StringLength(3, ErrorMessage =InvalidErrorMessages.Destination)]
        public string Destination { get; set; }

        [Required]
        public DateTime STA { get; set; }

        [Required]
        public DateTime STD { get; set; }

        public ArrivalMovement ArrivalMovement { get; set; }

        public DepartureMovement DepartureMovement { get; set; }

        public LoadDistributionMessage LDM { get; set; }


        [Required]
        [Range(0,189,ErrorMessage =(InvalidErrorMessages.BookedPax))]
        public int BookedPax { get; set; }
    }
}
