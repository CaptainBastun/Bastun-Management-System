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

        public void CreateInboundLDM(InboundFlight inboundFlight, LoadDistributionMessageDTO ldmDTO)
        {
            var loadDistributionMessage = _mapper.Map<LoadDistributionMessage>(ldmDTO);
            inboundFlight.InboundMessages.Add(loadDistributionMessage);
            _dbContext.LoadDistributionMessages.Add(loadDistributionMessage);
            _dbContext.SaveChanges();

     
        }

        public void CreateOutboundLDM(OutboundFlight outboundFlight, LoadDistributionMessageDTO  dto)
        {
            var outboundLoadDistributionMessage = _mapper.Map<LoadDistributionMessage>(dto);
            _dbContext.LoadDistributionMessages.Add(outboundLoadDistributionMessage);
            _dbContext.SaveChanges();

            outboundLoadDistributionMessage.Outbound = outboundFlight;
            outboundLoadDistributionMessage.OutboundFlightFlightNumber = outboundFlight.FlightNumber;
          
            _dbContext.SaveChanges();
        }

    }
}
