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

#nullable enable
        public string InboundFlightFlightNumber { get; set; }

       
        public virtual InboundFlight? Inbound { get; set; }

        
        public string OutboundFlightFlightNumber { get; set; }

        public virtual OutboundFlight? Outbound { get; set; }
#nullable disable
    }
}
