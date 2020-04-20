namespace BMS.Services.Contracts
{
    using BMS.Data.DTO;
    using BMS.Data.Models;
    using BMS.Data.Models.Contracts.FlightContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IMessageService
    {
        public void CreateInboundLDM(InboundFlight inbound,LoadDistributionMessageDTO inboundLDMDTO);

        public void CreateOutboundLDM(OutboundFlight outbound, LoadDistributionMessageDTO outboundLDMDTO);

        public void CreateInboundCPM(InboundFlight inbound, ContainerPalletMessageDTO inboundCPMDTO);

        public void CreateOutboundCPM(OutboundFlight outboundFlight,ContainerPalletMessageDTO outboundCPMDTO);

    }
}
