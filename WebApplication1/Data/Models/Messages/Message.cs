namespace BMS.Data.Models.Messages
{
    using System.ComponentModel.DataAnnotations;
    public abstract class Message
    {
        protected Message()
        {

        }

        [Key]
        public int MessageId { get; set; }

        
        public int? InboundFlightId { get; set; }

       
        public virtual InboundFlight? InboundFlight { get; set; }

        
        public int? OutboundFlightId { get; set; }

        public virtual OutboundFlight? OutboundFlight { get; set; }
    }
}
