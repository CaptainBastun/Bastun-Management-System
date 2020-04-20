namespace BMS.Services.Contracts
{
    using BMS.Data.Models;
    using BMS.Models;
    using BMS.Models.ViewModels.Flights;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IFlightService
    {
        Task<InboundFlight> GetInboundFlightByFlightNumber(string inboundFlightNumber);

        Task<OutboundFlight> GetOutboundFlightByFlightNumber(string outboundFlightNumber);

        Task CreateFlights(FlightInputModel flightInputModel);

        bool CheckIfFlightIsInbound(string flightNumber);

        bool CheckIfFlightIsOutbound(string flightNumber);

        DisplayDailyFlightViewModel GetAllFlights();
    }
}
