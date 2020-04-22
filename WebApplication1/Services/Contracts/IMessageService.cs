namespace BMS.Services.Contracts
{
    using BMS.Data.DTO;
    using BMS.Data.Models;

    public interface IMessageService
    {
        public void CreateInboundLDM(InboundFlight inbound,LoadDistributionMessageDTO inboundLDMDTO);

        public void CreateOutboundLDM(OutboundFlight outbound, LoadDistributionMessageDTO outboundLDMDTO);

    }
}
