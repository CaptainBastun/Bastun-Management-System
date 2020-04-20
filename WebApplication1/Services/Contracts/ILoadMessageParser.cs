namespace BMS.Services.Contracts
{
    using System.Threading.Tasks;
    public interface ILoadMessageParser
    {
        Task<bool> ParseInboundLoadDistributionMessage(string messageContent);

        Task<bool> ParseOutboundLoadDistributionMessage(string messageContent);
    }
}
