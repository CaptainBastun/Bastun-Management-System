namespace BMS.Services.Utility.UtilityContracts
{
    using BMS.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IFlightDataValidation
    {

        bool IsInboundContainerPalletMessageFlightDataValid(string[] splitMessageContent);

        bool IsOutboundContainerPalletMessageFlightDataValid(string[] splitMessageContent);

        bool IsArrivalMovementFlightDataValid(string[] splitMessageContent);

        bool IsDepartureMovementFlightDataValid(string[] splitMessageContent);

        bool IsInboundLoadDistributionMessageFlightDataValid(string[] splitMessageContent);

        bool IsOutboundLoadDistributionMessageFlightDataValid(string[] splitMessageContent);

    }
}
