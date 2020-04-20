namespace BMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IContainerMessageParser
    {
        Task<bool> ParseInboundContainerPalletMessage(string messageContent);

        Task<bool> ParseOutboundContainerPalletMessage(string messageContent);

    }
}
