namespace BMS.Services.Contracts
{
    using BMS.Data.LoadingInstructions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICabinAndHoldUtilityService

    {
        List<int> DetermineNumberOfHoldsToCreate(LoadingInstruction loadingInstruction);

        Dictionary<string,int> DetermineCabinZonesCapacity(string seatMap);
    }
}
