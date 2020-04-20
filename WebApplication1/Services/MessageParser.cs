namespace BMS.Services
{
    using BMS.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using BMS.Services.Utility.UtilityConstants;
    using BMS.Services.Utility.UtilityContracts;
    using BMS.Services.ParserUtility.UtilityContracts;

    public class MessageParser : IMessageParser
    {
        private readonly IMovementService _movementService;
        private readonly IMessageService _messageService;
        private readonly IFlightDataValidation _flightDataValidation;
        private readonly IFlightService _flightsService;
        private readonly IParserMovementUtility _parserMovementUtility;
        private readonly IParserContainerPalletMessageUtility _parserCPMUtility;
        private readonly ILoadControlService _loadControlService;
        private readonly Regex regex = new Regex("maika ti");
        private readonly Regex ldmFlightInfoRegex = new Regex(FlightInfoConstants.IsLDMFlightInfoValid);
        private readonly Regex loadDistributionRegex = new Regex(FlightInfoConstants.IsLDMLoadInfoValid);
        private readonly Regex loadSummaryRegex = new Regex(FlightInfoConstants.IsLDMLoadSummaryInfoValid);

    
        //TODO: Refactor this
        public MessageParser(IMovementService movementService, IMessageService messageService, IFlightDataValidation flightDataValidation, 
            IFlightService flightService,
            IParserMovementUtility parserMovementUtility, IParserContainerPalletMessageUtility parserCPMUtility, ILoadControlService loadControlService)
        {
            _movementService = movementService;
            _messageService = messageService;
            _flightDataValidation = flightDataValidation;
            _flightsService = flightService;
            _parserMovementUtility = parserMovementUtility;
            _parserCPMUtility = parserCPMUtility;
            _loadControlService = loadControlService;
        }

        public bool ParseArrivalMovement(string messageContent)
        {
            string[] splitMessage =
                messageContent.Split("\r\n", StringSplitOptions.None);

            if (this._flightDataValidation.IsArrivalMovementFlightDataValid(splitMessage))
            {
                //string[] flightData = _parserMovementUtility.GetMovementFlightData(splitMessage[1]); 
                //var inboundFlightByFlightNumber = _flightService.GetInboundFlightByFlightNumber(flightData[0]);
                //string[] arrivalMovementTimes = _parserMovementUtility.GetTimes(splitMessage[2]); 
                //DateTime[] validMovementTime = _parserMovementUtility.ParseMovementTimes(arrivalMovementTimes, inboundFlightByFlightNumber);
                //string supplementaryInformation = _ParseSupplementaryInformation(splitMessage[3]);
                //-movementService.CreateArrivalMovement(validMovementTime, supplementaryInformation, inboundFlightByFlightNumber);
                //return true; 
            } 
            return false;
        }

        public bool ParseInboundCPM(string messageContent)
        {
            ////method returns true if message has been created successfully 
            ////else returns false
            //string[] splitMessageContent =
            //    messageContent
            //    .Split("\r\n", StringSplitOptions.None);

            //if (this._flightDataValidation.IsCPMFlightDataValid(splitMessageContent))
            //{
            //    //var inbound = this.flightService.GetInboundFlightByFlightNumber(this.GetFlightNumber(splitMessageContent[1]));
            //    //string supplementaryInformation = this.ParseSupplementaryInformation(splitMessageContent[splitMessageContent.Length - 1]);
            //    //int amountOfInboundContainers = this.parserCPMUtility.GetContainerCount(splitMessageContent);
            //    //var listOfContainersForCurrentMessage = _loadControlService.AddContainersToInboundFlight(inbound,amountOfInboundContainers);
            //    //var listofContainerInfo =  _loadControlService.CreateContainerInfo(splitMessageContent, listOfContainersForCurrentMessage);
            //    //var dto = new CPMDTO(listofContainerInfo, supplementaryInformation);
            //    //this.messageService.CreateInboundCPM(inbound, dto);
            //} 
            //else
            //{
            //    return false;
            //}
              
            //return true;
        }


        private string ParseSupplementaryInformation(string supplementaryInfo)
        {
            string result = string.Empty;

            if (!supplementaryInfo.Contains("NIL"))
            {
                //TODO: Test for arrival movement
                string[] splitData = supplementaryInfo
                    .Split("SI", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string actualData = splitData[0];
                result = actualData;
            }
            result = "NIL";

            return result;
        }

        private int ParseTotalPax(string totalPax)
        {
            return int.Parse(totalPax.Remove(0, 3));
        }

       

        public bool ParseOutboundCPM(string messageContent)
        {
            //string[] splitMessageContent =
            //    messageContent
            //    .Split("\r\n", StringSplitOptions.None);
   
            //if (this.flightDataValidation.IsCPMFlightDataValid(splitMessageContent))
            //{
            //    var outbound = _flightService.GetOutboundFlightByFlightNumber(this.GetFlightNumber(splitMessageContent[1]));
            //    string supplementaryInformation = ParseSupplementaryInformation(splitMessageContent[splitMessageContent.Length - 1]);
            //    int amountOfInboundContainers = _parserCPMUtility.GetContainerCount(splitMessageContent);
            //    var listOfContainersForCurrentMessage = _loadControlService.AddContainersToOutboundFlight(outbound, amountOfInboundContainers);
            //    var listofContainerInfo = _loadControlService.CreateContainerInfo(splitMessageContent, listOfContainersForCurrentMessage);
            //    var cpmDTO = new CPMDTO(listofContainerInfo, supplementaryInformation);
            //    this.messageService.CreateOutboundCPM(outbound, cpmDTO);
            //}
          

            return true;
        }


        public bool ParseInboundLDM(string messageContent)
        {
            //string[] splitMessage =
            //    messageContent
            //    .Split("\r\n", StringSplitOptions.None);
         
            //if (this.flightDataValidation.IsLDMFlightDataValid(splitMessage))
            //{
            //    var ldmFlightInfoMatch = ldmFlightInfoRegex.Match(splitMessage[1]);

            //    if (ldmFlightInfoMatch.Success)
            //    {
            //        string inboundFlightNumber = ldmFlightInfoMatch.Groups["flt"].Value;
            //        string crewConfiguration = ldmFlightInfoMatch.Groups["crewConfig"].Value;
            //        var loadMatch = loadDistributionRegex.Match(splitMessage[2]);

            //        if (loadMatch.Success)
            //        {
            //            int[] paxFigures = ParsePAXFigures(splitMessage[2]);

            //            int totalWeightInCompartments = ParseLDMTotalWeight(loadMatch.Groups["ttlWghtInCpt"].Value);
            //            var weightInEachCompartment = ParseWeightsInCompartments(loadMatch.Groups["wghtByCompartment"].Value);
            //            var loadSummaryMatch = loadSummaryRegex.Match(splitMessage[3]);

            //            if (loadSummaryMatch.Success)
            //            {
            //               int[] loadSummaryInfo = ParseLoadSummaryInfo(splitMessage[3]);
            //               var inboundFlight = _flightService.GetInboundFlightByFlightNumber(inboundFlightNumber);
            //               var dto = new LDMDTO(crewConfiguration, paxFigures, totalWeightInCompartments, weightInEachCompartment, loadSummaryInfo);
            //              _messageService.CreateInboundLDM(inboundFlight, dto);

            //            }
            //        }
            //    }
            //} 
            return false;
        }

        public bool ParseOutboundLDM(string messageContent)
        {
            //string[] splitMessage =
            //       messageContent
            //       .Split("\r\n", StringSplitOptions.None);

            //if (this.flightDataValidation.IsLDMFlightDataValid(splitMessage))
            //{
            //    var ldmFlightInfoMatch = ldmFlightInfoRegex.Match(splitMessage[1]);

            //    if (ldmFlightInfoMatch.Success)
            //    {

            //        string outboundFlightNumber = ldmFlightInfoMatch.Groups["flt"].Value;
            //        string crewConfiguration = ldmFlightInfoMatch.Groups["crewConfig"].Value;
            //        var loadMatch = loadDistributionRegex.Match(splitMessage[2]);
            //        if (loadMatch.Success)
            //        {
            //            int[] paxFigures = ParsePAXFigures(splitMessage[2]);
            //            int totalWeightInCompartments = ParseLDMTotalWeight(loadMatch.Groups["ttlWghtInCpt"].Value);
            //            var weightInEachCompartment = ParseWeightsInCompartments(loadMatch.Groups["wghtByCompartment"].Value);
            //            var loadSummaryMatch = loadSummaryRegex.Match(splitMessage[3]);
            //            if (loadSummaryMatch.Success)
            //            {
            //                int[] loadSummaryInfo = ParseLoadSummaryInfo(splitMessage[3]);
            //                var outboundFlight = _flightService.GetOutboundFlightByFlightNumber(outboundFlightNumber);
            //                var dto = new LDMDTO(crewConfiguration, paxFigures, totalWeightInCompartments, weightInEachCompartment, loadSummaryInfo);
            //               _messageService.CreateOutboundLDM(outboundFlight, dto);
            //            }
            //        }
            //    }
            //}
      
            return false;
        }


        private int ParseLDMTotalWeight(string totalWeightInCPT)
        {
            string[] splitData =
                totalWeightInCPT.Split(".", StringSplitOptions.RemoveEmptyEntries);

            int totalWeight = int.Parse(splitData[1]);

            return totalWeight;
        }

        private int ParseLDMTotalPax(string totalPax)
        {
            string[] splitData =
                totalPax
                .Split("/", StringSplitOptions.RemoveEmptyEntries);

            return int.Parse(splitData[1]);
        }

        private int ParseLDMTotalBags(string totalBags)
        {
            string[] splitData =
                totalBags.Split("/", StringSplitOptions.RemoveEmptyEntries);

            return int.Parse(splitData[1]);
        }

        private int ParseLDMCargo(string cargo)
        {
            string[] splitData =
                cargo.Split("/", StringSplitOptions.RemoveEmptyEntries);

            if (splitData[1] == "NIL")
            {
                return 0;
            }

            return int.Parse(splitData[1]);
        }

        private Dictionary<int,int> ParseWeightsInCompartments(string input)
        {
            var weightInCompartments = new Dictionary<int, int>();
            string[] splitByCompartments =
                input
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

        private int[] ParsePAXFigures(string input)
        {
            int inboundPaxMale = 0;
            int inboundPaxFemale = 0;
            int inboundPaxChildren = 0;
            int inboundPaxInfants = 0;
            var match = this.loadDistributionRegex.Match(input);
            
            if (match.Success)
            {
                inboundPaxMale = int.Parse(match.Groups["M"].Value);
                inboundPaxFemale = int.Parse(match.Groups["female"].Value);
                inboundPaxChildren = int.Parse(match.Groups["children"].Value);
                inboundPaxInfants = int.Parse(match.Groups["infants"].Value);

            }

            return new int[] { inboundPaxMale, inboundPaxFemale, inboundPaxChildren, inboundPaxInfants };
        }

        private int[] ParseLoadSummaryInfo(string input)
        {
            int totalPax = 0;
            int totalBags = 0;
            int totalCargo = 0;
            var match = loadSummaryRegex.Match(input);
            if (match.Success)
            {
                totalPax = this.ParseLDMTotalPax(match.Groups["PAX"].Value);
                totalBags = this.ParseLDMTotalBags(match.Groups["bags"].Value);
                totalCargo = this.ParseLDMCargo(match.Groups["cargo"].Value);
            }

            return new int[] { totalPax, totalBags, totalCargo };
        }
    }

    
}
