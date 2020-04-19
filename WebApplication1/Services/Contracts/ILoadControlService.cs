namespace BMS.Services.Contracts
{
    using BMS.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface ILoadControlService
    {
        void CalculatePAXWeightByGender();

        void GetPassengersByZoneDistribution();

        string GetCorrectLoadingInstruction(string aircraftType);

        List<Container> AddContainersToInboundFlight(InboundFlight inbound, int amountOfInboundContainersToCreate);

        List<Container> AddContainersToOutboundFlight(OutboundFlight outbond, int amountOfOutboundContainersToCreate);


        List<ContainerInfo> CreateContainerInfo(string[] splitMessage, List<Container> containers);

    }
}
