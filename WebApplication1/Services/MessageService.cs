namespace BMS.Services
{
    using BMS.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BMS.Models;
    using WebApplication1.Data;
    using BMS.Data.Models;
    using BMS.Data.Models.Messages;
    using BMS.Data.DTO;
    using AutoMapper;

    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MessageService(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void CreateInboundCPM(InboundFlight inbound, ContainerPalletMessageDTO dto)
        {
            var inboundContainerPalletMessage = _mapper.Map<ContainerPalletMessage>(dto);
            _dbContext.ContainerPalletMessages.Add(inboundContainerPalletMessage);
            _dbContext.SaveChanges();

            inboundContainerPalletMessage.InboundFlight = inbound;
            inboundContainerPalletMessage.InboundFlightId = inbound.FlightId;
        }

        public void CreateInboundLDM(InboundFlight inboundFlight, LoadDistributionMessageDTO ldmDTO)
        {
            var loadDistributionMessage = _mapper.Map<LoadDistributionMessage>(ldmDTO);
            _dbContext.LoadDistributionMessages.Add(loadDistributionMessage);
            _dbContext.SaveChanges();

            loadDistributionMessage.InboundFlight = inboundFlight;
            loadDistributionMessage.InboundFlightId = inboundFlight.FlightId;
            _dbContext.SaveChanges();
        }

        public void CreateOutboundCPM(OutboundFlight outboundFlight, ContainerPalletMessageDTO dto)
        {
            var outboundContainerPalletMessage = _mapper.Map<ContainerPalletMessage>(dto);
            _dbContext.ContainerPalletMessages.Add(outboundContainerPalletMessage);
            _dbContext.SaveChanges();

            outboundContainerPalletMessage.OutboundFlight = outboundFlight;
            outboundContainerPalletMessage.OutboundFlightId = outboundFlight.FlightId;
            outboundFlight.OutboundMessages.Add(outboundContainerPalletMessage);
            _dbContext.SaveChanges();
        }

        public void CreateOutboundLDM(OutboundFlight outboundFlight, LoadDistributionMessageDTO  dto)
        {
            var outboundLoadDistributionMessage = _mapper.Map<LoadDistributionMessage>(dto);
            _dbContext.LoadDistributionMessages.Add(outboundLoadDistributionMessage);
            _dbContext.SaveChanges();

            outboundLoadDistributionMessage.OutboundFlight = outboundFlight;
            outboundLoadDistributionMessage.OutboundFlightId = outboundFlight.FlightId;
          
            _dbContext.SaveChanges();
        }

    }
}
