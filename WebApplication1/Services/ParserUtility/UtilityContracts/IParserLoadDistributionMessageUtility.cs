namespace BMS.Services.ParserUtility.UtilityContracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IParserLoadDistributionMessageUtility
    {
        int ParseLoadDistributionMessageTotalWeight(string totalWeightInCompartments);

        int ParseLoadDistributionMessageTotalPax(string totalPax);

        int ParseLoadDistributionMessageTotalBags(string totalBags);

        int ParseLoadDistributionMessageTotalCargo(string totalCargo);

        Dictionary<int, int> ParseWeightsInCompartments(string weightsInCompartments);

        int[] ParseLoadDistributionMessagePaxFigures(string paxFigures);

        int[] ParseLoadSummaryInfo(string input);
    }
}
