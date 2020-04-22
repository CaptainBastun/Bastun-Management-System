namespace BMS.Data.Models
{
    using BMS.Data.Models.Messages;
    using BMS.GlobalData;
    using BMS.GlobalData.ErrorMessages;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
   
    public class InboundFlight
    {
        public InboundFlight()
        {
            InboundMessages = new HashSet<Message>();
        }

        [Key]
        [Required(ErrorMessage = InvalidErrorMessages.FlightNumberRequired)]
        [RegularExpression(FlightInputDataValidation.GeneralFlightNumberValidation, ErrorMessage = InvalidErrorMessages.InvalidFlightNumberFormat)]
        public string FlightNumber { get; set; }

        public int ArrivalMovementId { get; set; }

        public virtual ArrivalMovement ArrivalMovement { get; set; }

        [Required(ErrorMessage = InvalidErrorMessages.OriginRequired)]
        [RegularExpression(FlightInputDataValidation.StationValidation, ErrorMessage = InvalidErrorMessages.Origin)]
        public string Origin { get; set; }

        public virtual ICollection<Message> InboundMessages { get; set; }
        public DateTime STA { get ; set ; }

    }
}
