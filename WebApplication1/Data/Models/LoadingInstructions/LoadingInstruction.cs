namespace BMS.Data.LoadingInstructions
{
    using BMS.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    public class LoadingInstruction
    {
        //indicates how many suitcases 
        //are meant to be put in each hold compartment of the aircraft  

        [Key]
        public int Id { get; set; }

        public string OutboundFlightFlightNumber { get; set; }

        public virtual OutboundFlight OutboundFlight { get; set; }

        public int HoldOnePieces { get; set; }

        public int HoldTwoPieces { get; set; }

        public int HoldThreePieces { get; set; }

        public int HoldFourPieces { get; set; }

        public int HoldFivePieces { get; set; }
    }
}
