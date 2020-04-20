namespace BMS.Services
{
    using BMS.Data.DTO;
    using BMS.Services.Contracts;
    using BMS.Services.ParserUtility.UtilityContracts;
    using BMS.Services.Utility.UtilityConstants;
    using BMS.Services.Utility.UtilityContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    public class ContainerMessageParser : IContainerMessageParser
    {
        private readonly IFlightDataValidation _flightDataValidation;
        private readonly IFlightService _flightsService;
        private readonly IParserContainerPalletMessageUtility _parserContainerPalletMessageUtility;
        private readonly ILoadControlService _loadControlService;
        private readonly IMessageService _messageService;
        private readonly Regex _flightInfoRegex;

        public ContainerMessageParser(IFlightDataValidation flightDataValidation,
             IFlightService flightsService, IParserContainerPalletMessageUtility parserCPMUtility,
             ILoadControlService loadControlService, IMessageService messageService)
        {
            _flightDataValidation = flightDataValidation;
            _flightsService = flightsService;
            _parserContainerPalletMessageUtility = parserCPMUtility;
            _loadControlService = loadControlService;
            _messageService = messageService;
            _flightInfoRegex = new Regex(FlightInfoConstants.IsLDMFlightInfoValid);
        }

        public async Task<bool> ParseInboundContainerPalletMessage(string messageContent)
        {

            string[] splitMessageContent =
                messageContent
                .Split("\r\n", StringSplitOptions.None);

            if (_flightDataValidation.IsCPMFlightDataValid(splitMessageContent))
            {
                var inbound = await _flightsService.GetInboundFlightByFlightNumber(GetFlightNumber(splitMessageContent[1]));
                string supplementaryInformation = ParseSupplementaryInformation(splitMessageContent[splitMessageContent.Length - 1]);

                int amountOfInboundContainers = _parserContainerPalletMessageUtility.GetContainerCount(splitMessageContent);
                var listOfContainersForCurrentMessage = _loadControlService.AddContainersToInboundFlight(inbound, amountOfInboundContainers);
                var listofContainerInfo = _loadControlService.CreateContainerInfo(splitMessageContent, listOfContainersForCurrentMessage);

                var containerPalletMessageDTO = new ContainerPalletMessageDTO(listofContainerInfo, supplementaryInformation);
                _messageService.CreateInboundCPM(inbound, containerPalletMessageDTO);

                return true;
            }

            return false;
        }

        public async Task<bool> ParseOutboundContainerPalletMessage(string messageContent)
        {
            string[] splitMessageContent =
                messageContent
                .Split("\r\n", StringSplitOptions.None);

            if (_flightDataValidation.IsCPMFlightDataValid(splitMessageContent))
            {
                var outbound = await _flightsService.GetOutboundFlightByFlightNumber(GetFlightNumber(splitMessageContent[1]));
                string supplementaryInformation = ParseSupplementaryInformation(splitMessageContent[splitMessageContent.Length - 1]);
                int amountOfInboundContainers = _parserContainerPalletMessageUtility.GetContainerCount(splitMessageContent);
                var listOfContainersForCurrentMessage = _loadControlService.AddContainersToOutboundFlight(outbound, amountOfInboundContainers);
                var listofContainerInfo = _loadControlService.CreateContainerInfo(splitMessageContent, listOfContainersForCurrentMessage);
                var containerPalletMessageDTO = new ContainerPalletMessageDTO(listofContainerInfo, supplementaryInformation);
                _messageService.CreateOutboundCPM(outbound, containerPalletMessageDTO);
               
                return true;
            }

            return false;
        }

        private string GetFlightNumber(string message)
        {
            var match = _flightInfoRegex.Match(message);

            if (match.Success)
            {
                return match.Groups["flt"].Value;
            }

            return null;
        }

        private string ParseSupplementaryInformation(string info)
        {
            if (!info.Contains(FlightInfoConstants.NILSupplementaryInfo))
            {
                string[] splitData = info
                    .Split("SI", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                return splitData[0];
            }

            return FlightInfoConstants.NILSupplementaryInfo;
        }
    } 
}
