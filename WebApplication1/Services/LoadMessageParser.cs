namespace BMS.Services
{
    using BMS.Data.DTO;
    using BMS.Services.Contracts;
    using BMS.Services.ParserUtility.UtilityContracts;
    using BMS.Services.Utility.UtilityConstants;
    using BMS.Services.Utility.UtilityContracts;
    using System;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class LoadMessageParser : ILoadMessageParser
    {
        private readonly IFlightDataValidation _flightDataValidation;
        private readonly IParserLoadDistributionMessageUtility _parserLoadDistributionMessageUtility;
        private readonly IFlightService _flightsService;
        private readonly IMessageService _messageService;
        private readonly Regex _ldmFlightInfoRegex;
        private readonly Regex _ldmLoadDistributionRegex;
        private readonly Regex _ldmLoadSummaryRegex;

        public LoadMessageParser(IFlightDataValidation flightDataValidation,
            IParserLoadDistributionMessageUtility parserLoadDistributionMessageUtility,
            IFlightService flightsService, IMessageService messageService)
        {
            _flightDataValidation = flightDataValidation;
            _parserLoadDistributionMessageUtility = parserLoadDistributionMessageUtility;
            _flightsService = flightsService;
            _messageService = messageService;
            _ldmFlightInfoRegex = new Regex(FlightInfoConstants.IsLDMFlightInfoValid);
            _ldmLoadDistributionRegex = new Regex(FlightInfoConstants.IsLDMLoadInfoValid);
            _ldmLoadSummaryRegex = new Regex(FlightInfoConstants.IsLDMLoadSummaryInfoValid);
        }

        public async Task<bool> ParseInboundLoadDistributionMessage(string messageContent)
        {
            string[] splitMessage =
               messageContent
               .Split("\r\n", StringSplitOptions.None);

            if (_flightDataValidation.IsInboundLoadDistributionMessageFlightDataValid(splitMessage))
            {
                var ldmFlightInfoMatch = _ldmFlightInfoRegex.Match(splitMessage[1]);

                if (ldmFlightInfoMatch.Success)
                {
                    string inboundFlightNumber = ldmFlightInfoMatch.Groups["flt"].Value;
                    string crewConfiguration = ldmFlightInfoMatch.Groups["crewConfig"].Value;

                    var loadMatch = _ldmLoadDistributionRegex.Match(splitMessage[2]);
                    if (loadMatch.Success)
                    {
                        int[] paxFigures = _parserLoadDistributionMessageUtility.ParseLoadDistributionMessagePaxFigures(splitMessage[2]);
                        int totalWeightInCompartments = _parserLoadDistributionMessageUtility.ParseLoadDistributionMessageTotalWeight(loadMatch.Groups["ttlWghtInCpt"].Value);
                        var weightInEachCompartment = _parserLoadDistributionMessageUtility.ParseWeightsInCompartments(loadMatch.Groups["wghtByCompartment"].Value);

                        var loadSummaryMatch = _ldmLoadSummaryRegex.Match(splitMessage[3]);
                        if (loadSummaryMatch.Success)
                        {
                            int[] loadSummaryInfo = _parserLoadDistributionMessageUtility.ParseLoadSummaryInfo(splitMessage[3]);
                            var inboundFlight = await _flightsService.GetInboundFlightByFlightNumber(inboundFlightNumber);
                            var loadDistributionMessageDTO = new LoadDistributionMessageDTO(crewConfiguration, paxFigures, totalWeightInCompartments, weightInEachCompartment, loadSummaryInfo);
                            _messageService.CreateInboundLDM(inboundFlight, loadDistributionMessageDTO);
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        public async Task<bool> ParseOutboundLoadDistributionMessage(string messageContent)
        {
           string[] splitMessage =
                   messageContent
                   .Split("\r\n", StringSplitOptions.None);

            if (_flightDataValidation.IsOutboundLoadDistributionMessageFlightDataValid(splitMessage))
            {
                  var ldmFlightInfoMatch = _ldmFlightInfoRegex.Match(splitMessage[1]);
                 if (ldmFlightInfoMatch.Success)
                 {
                    string outboundFlightNumber = ldmFlightInfoMatch.Groups["flt"].Value;
                    string crewConfiguration = ldmFlightInfoMatch.Groups["crewConfig"].Value;

                    var loadMatch = _ldmLoadDistributionRegex.Match(splitMessage[2]);
                    if (loadMatch.Success)
                    {
                        int[] paxFigures = _parserLoadDistributionMessageUtility.ParseLoadDistributionMessagePaxFigures(splitMessage[2]);
                        int totalWeightInCompartments = _parserLoadDistributionMessageUtility.ParseLoadDistributionMessageTotalWeight(loadMatch.Groups["ttlWghtInCpt"].Value);
                        var weightInEachCompartment = _parserLoadDistributionMessageUtility.ParseWeightsInCompartments(loadMatch.Groups["wghtByCompartment"].Value);

                        var loadSummaryMatch = _ldmLoadSummaryRegex.Match(splitMessage[3]);
                        if (loadSummaryMatch.Success)
                        {
                            int[] loadSummaryInfo = _parserLoadDistributionMessageUtility.ParseLoadSummaryInfo(splitMessage[3]);
                            var outboundFlight = await _flightsService.GetOutboundFlightByFlightNumber(outboundFlightNumber);
                            var loadDistributionMessageDTO = new LoadDistributionMessageDTO(crewConfiguration, paxFigures, totalWeightInCompartments, weightInEachCompartment, loadSummaryInfo);
                           _messageService.CreateOutboundLDM(outboundFlight, loadDistributionMessageDTO);

                            return true;
                        }
                    }
                 }
            }
            return false;
        }
    } 
}
