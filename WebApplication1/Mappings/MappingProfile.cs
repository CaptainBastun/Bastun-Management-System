namespace BMS.Mappings
{
    using AutoMapper;
    using BMS.Data.DTO;
    using BMS.Data.DTO.MovementsDTO;
    using BMS.Data.Models;
    using BMS.Data.Models.Messages;
    using BMS.Models;
    using BMS.Models.FlightInputModels;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InboundFlightInputModel, InboundFlight>();

            CreateMap<OutboundFlightInputModel, OutboundFlight>();

            CreateMap<ArrivalMovementDTO, ArrivalMovement>();

            CreateMap<DepartureMovementDTO, DepartureMovement>();

            CreateMap<AircraftInputModel, Aircraft>();
                
            CreateMap<LoadDistributionMessageDTO, LoadDistributionMessage>();

        }
    }
}
