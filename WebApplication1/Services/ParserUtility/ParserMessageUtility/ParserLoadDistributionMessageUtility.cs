namespace BMS.Services.ParserUtility
{
    using BMS.Services.ParserUtility.UtilityContracts;
    using BMS.Services.Utility.UtilityConstants;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ParserLoadDistributionMessageUtility : IParserLoadDistributionMessageUtility
    {
        private readonly Regex _loadDistributionRegex = new Regex(FlightInfoConstants.IsLDMLoadInfoValid);
        private readonly Regex _loadSummaryRegex = new Regex(FlightInfoConstants.IsLDMLoadSummaryInfoValid);

        public int[] ParseLoadDistributionMessagePaxFigures(string paxFigures)
        {
            int inboundPaxMale = 0;
            int inboundPaxFemale = 0;
            int inboundPaxChildren = 0;
            int inboundPaxInfants = 0;
            var match = _loadDistributionRegex.Match(paxFigures);

            if (match.Success)
            {
                inboundPaxMale = int.Parse(match.Groups["M"].Value);
                inboundPaxFemale = int.Parse(match.Groups["female"].Value);
                inboundPaxChildren = int.Parse(match.Groups["children"].Value);
                inboundPaxInfants = int.Parse(match.Groups["infants"].Value);

            }

            return new int[] { inboundPaxMale, inboundPaxFemale, inboundPaxChildren, inboundPaxInfants };
        }

        public int ParseLoadDistributionMessageTotalBags(string totalBags)
        {
            string[] splitData =
                totalBags.Split("/", StringSplitOptions.RemoveEmptyEntries);

            return int.Parse(splitData[1]);
        }

        public int ParseLoadDistributionMessageTotalCargo(string totalCargo)
        {
            string[] splitData =
                totalCargo.Split("/", StringSplitOptions.RemoveEmptyEntries);

            if (splitData[1] == "NIL")
            {
                return 0;
            }

            return int.Parse(splitData[1]);
        }

        public int ParseLoadDistributionMessageTotalPax(string totalPax)
        {
            string[] splitData =
                 totalPax
                 .Split("/", StringSplitOptions.RemoveEmptyEntries);

            return int.Parse(splitData[1]);
        }

        public int ParseLoadDistributionMessageTotalWeight(string totalWeightInCompartments)
        {
            string[] splitData =
                 totalWeightInCompartments.Split(".", StringSplitOptions.RemoveEmptyEntries);

            return int.Parse(splitData[1]);
        }

        public int[] ParseLoadSummaryInfo(string input)
        {
            int totalPax = 0;
            int totalBags = 0;
            int totalCargo = 0;

            var match = _loadSummaryRegex.Match(input);

            if (match.Success)
            {
                totalPax = ParseLoadDistributionMessageTotalPax(match.Groups["PAX"].Value);
                totalBags = ParseLoadDistributionMessageTotalBags(match.Groups["bags"].Value);
                totalCargo = ParseLoadDistributionMessageTotalCargo(match.Groups["cargo"].Value);
            }

            return new int[] { totalPax, totalBags, totalCargo };
        }

        public Dictionary<int, int> ParseWeightsInCompartments(string weightsInCompartments)
        {
            var weightInCompartments = new Dictionary<int, int>();

            string[] splitByCompartments =
                 weightsInCompartments
                .Split(".", StringSplitOptions.RemoveEmptyEntries);

            foreach (var compartment in splitByCompartments)
            {
                string[] splitData =
                     compartment
                     .Split("/", StringSplitOptions.RemoveEmptyEntries);

                int compartmentNumber = int.Parse(splitData[0]);
                int weight = int.Parse(splitData[1]);
                weightInCompartments.Add(compartmentNumber, weight);
            }
            return weightInCompartments;
        }
    }
}
