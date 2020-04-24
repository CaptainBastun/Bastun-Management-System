namespace BMS.Mappings
{
    using AutoMapper;
    using BMS.Data;
    using BMS.Data.DTO;
    using BMS.Data.DTO.MovementsDTO;
    using BMS.Data.LoadingInstructions;
    using BMS.Data.Models;
    using BMS.Data.Models.Messages;
    using BMS.Models;
    using BMS.Models.FlightInputModels;
    using BMS.Models.ViewModels.Passengers;

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

            CreateMap<BulkLoadingInstructionInputModel, LoadingInstruction>();

            CreateMap<FuelFormInputModel,FuelForm>();

            CreateMap<WeightFormInputModel, WeightForm>();

            CreateMap<PAXInputModel, Passenger>();

            CreateMap<PAXSuitcaseInputModel, Suitcase>();

            CreateMap<Passenger, PassengerOffloadEditViewModel>()
                .ForMember(dest => dest.Gender, src => src.MapFrom(g => g.Gender.ToString()))
                .ForMember(dest => dest.Id, src => src.MapFrom(i => i.PaxId));

            CreateMap<PAXSuitcaseInputModel, Suitcase>();
        }
    }
}
