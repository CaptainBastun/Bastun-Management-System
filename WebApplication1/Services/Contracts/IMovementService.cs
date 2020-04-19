namespace BMS.Services.Contracts
{
    using BMS.Data.DTO.MovementsDTO;
    using BMS.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IMovementService
    {
        Task CreateArrivalMovement(ArrivalMovementDTO movementDTO, InboundFlight inbound);

        Task CreateDepartureMovement(DepartureMovementDTO movementDTO, OutboundFlight outbound);

        Task<ArrivalMovement> GetArrivalMovementByFlightNumber(string flightNumber);

        Task<DepartureMovement> GetDepartureMovementByFlightNumber(string flightNumber);
    }
}
