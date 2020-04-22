namespace BMS.Models
{
    using BMS.GlobalData.LoadConstants;
    using BMS.GlobalData.ErrorMessages;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    public class BulkLoadingInstructionInputModel
    {
        //Dictates how many pieces of baggage are supposed to be in each baggage hold

        [Required(ErrorMessage = "Flight number is required")] 
        public string FlightNumber { get; set; }

        [Range(0, LoadingInstructionConstants.HoldOnePieces, ErrorMessage = InvalidLoadInstructionErrorMessages.HoldOneCapacityExceeded)]
        public int HoldOnePieces { get; set; }

        [Range(0,LoadingInstructionConstants.HoldTwoPieces, ErrorMessage = InvalidLoadInstructionErrorMessages.HoldTwoCapacityExceeded)]
        public int HoldTwoPieces { get; set; }

        [Range(0, LoadingInstructionConstants.HoldThreePieces, ErrorMessage = InvalidLoadInstructionErrorMessages.HoldThreeCapacityExceeded)]
        public int HoldThreePieces { get; set; }

        [Range(0, LoadingInstructionConstants.HoldFourPieces, ErrorMessage = InvalidLoadInstructionErrorMessages.HoldFourCapacityExceeded)]
        public int HoldFourPieces { get; set; }

        [Range(0, LoadingInstructionConstants.HoldFivePieces, ErrorMessage = InvalidLoadInstructionErrorMessages.HoldFiveCapacityExceeded)]
        public int HoldFivePieces { get; set; }
    }
}
