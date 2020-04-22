namespace BMS.Data.Models
{
    using BMS.Data.LoadingInstructions;
    using BMS.Data.Models.Messages;
    using BMS.GlobalData;
    using BMS.GlobalData.ErrorMessages;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class OutboundFlight
    {
        public OutboundFlight()
        {
         
            OutboundMessages = new HashSet<Message>();
        }

        [Key]
        [Required(ErrorMessage = InvalidErrorMessages.FlightNumberRequired)]
        [RegularExpression(FlightInputDataValidation.GeneralFlightNumberValidation, ErrorMessage = InvalidErrorMessages.InvalidFlightNumberFormat)]
        public string FlightNumber { get; set; }

        public int AircraftId { get; set; }
        public virtual Aircraft Aircraft { get; set; }

        public string HandlingStation { get; set; }

        [Required(ErrorMessage = InvalidErrorMessages.DestinationRequired)]
        [RegularExpression(FlightInputDataValidation.StationValidation, ErrorMessage = InvalidErrorMessages.Destination)]
        public string Destination { get; set; }

        public virtual ICollection<Message> OutboundMessages { get; set; }

        public int DepartureMovementId { get; set; }

        public virtual DepartureMovement DepartureMovement { get; set; }

        [Required(ErrorMessage = InvalidErrorMessages.BookedPAXRequired)]
        [Range(0,345, ErrorMessage = InvalidErrorMessages.BookedPax)]
        public int BookedPAX { get; set; }

        public bool IsDeparted { get; set; }

        public int LoadingInstructionId { get; set; }

        public virtual LoadingInstruction LoadingInstruction { get; set; }

        public DateTime STD { get ; set; }

        [Required(ErrorMessage = InvalidErrorMessages.SeatMapRequired)]
        [RegularExpression(FlightInputDataValidation.SeatMapValidation, ErrorMessage = InvalidErrorMessages.SeatMapIsInvalid)]
        public string SeatMap { get ; set ; }

        [Required(ErrorMessage = InvalidErrorMessages.RampAgentNameRequired)]
        public string RampAgentName { get ; set; }
    }
}
