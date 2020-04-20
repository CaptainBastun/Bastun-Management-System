namespace BMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IMovementParser
    {
        Task<bool> ParseArrivalMovement(string messageData);

        Task<bool> ParseDepartureMovement(string messageData);

    }
}
