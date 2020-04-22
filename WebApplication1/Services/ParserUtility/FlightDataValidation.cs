namespace BMS.Services.Utility
{
    using BMS.Services.ParserUtility;
    using BMS.Services.Contracts;
    using BMS.Services.Utility.UtilityContracts;
    using System.Text.RegularExpressions;
    using BMS.Services.Utility.UtilityConstants;
    using System.Collections.Generic;

    public class FlightDataValidation : IFlightDataValidation
    {
       
        private readonly IFlightService _flightsService;
        private readonly IAircraftService _aircraftService;
 
        public FlightDataValidation(IFlightService flightsService, IAircraftService aircraftService)
        {
            _flightsService = flightsService;
            _aircraftService = aircraftService;
        }

  
        public bool IsInboundContainerPalletMessageFlightDataValid(string[] splitMessageContent)
        {
            if (MessageValidation.IsCPMMessageTypeValid(splitMessageContent[0]))
            {
                var flightRegex = new Regex(FlightInfoConstants.IsFlightInfoValid);
                var match = flightRegex.Match(splitMessageContent[1]);

                if (match.Success)
                {
                    string flightNumber = match.Groups["flt"].Value;
                    string date = match.Groups["date"].Value;
                    string registration = match.Groups["reg"].Value;
                    string station = match.Groups["origin"].Value;

                    if (MessageValidation.IsFlightInfoNotNullOrWhitespace(flightNumber, registration,date,station))
                    {
                        if (_flightsService.CheckIfFlightIsInbound(flightNumber))
                        {
                            if (_aircraftService.CheckAircraftRegistration(registration))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }



        public  bool IsArrivalMovementFlightDataValid(string[] splitMessageContent)
        {
            if (MessageValidation.IsMovementMessageTypeValid(splitMessageContent[0]))
            {
                var regex = new Regex(FlightInfoConstants.IsFlightInfoValid);

                var match = regex.Match(splitMessageContent[1]);
                if (match.Success)
                {
                    string flightNumber = match.Groups["flt"].Value;
                    string registration = match.Groups["reg"].Value;
                    string date = match.Groups["date"].Value;
                    string station = match.Groups["origin"].Value;

                    if (MessageValidation.IsFlightInfoNotNullOrWhitespace(flightNumber, registration,date, station))
                    {
                        if (_flightsService.CheckIfFlightIsInbound(flightNumber))
                        {
                            if (_aircraftService.CheckAircraftRegistration(registration))
                            {
                                return true;
                            }
                        }
                    } 
                }
            } 
            return false;
        }

        public bool IsInboundLoadDistributionMessageFlightDataValid(string[] splitMessageContent)
        {
            if (MessageValidation.IsLoadDistributionMessageTypeValid(splitMessageContent[0]))
            {
                var flightDataRegex = new Regex(FlightInfoConstants.IsLDMFlightInfoValid);
                var match = flightDataRegex.Match(splitMessageContent[1]);

                if (match.Success)
                {
                    string fltNumber = match.Groups["flt"].Value;
                    string registration = match.Groups["reg"].Value;

                    if (_flightsService.CheckIfFlightIsInbound(fltNumber))
                    {
                        if (_aircraftService.CheckAircraftRegistration(registration))
                        {
                            return true;
                        }
                    }
                }
            } 
            return true;
        }

        public bool IsDepartureMovementFlightDataValid(string[] splitMessageContent)
        {
            string messageType = splitMessageContent[0];

            if (MessageValidation.IsMovementMessageTypeValid(messageType))
            {
                var flightRegex = new Regex(FlightInfoConstants.IsFlightInfoValid);
                var match = flightRegex.Match(splitMessageContent[1]);

                if (match.Success)
                {
                  
                    string flightNumber = match.Groups["flt"].Value;
                    string registration = match.Groups["reg"].Value;
                    string date = match.Groups["date"].Value;
                    string station = match.Groups["origin"].Value;


                    if (MessageValidation.IsFlightInfoNotNullOrWhitespace(flightNumber, registration, date, station))
                    {
                        if (_flightsService.CheckIfFlightIsOutbound(flightNumber))
                        {
                            if (_aircraftService.CheckAircraftRegistration(registration))
                            {
                                return true;
                            }
                        }
                    } 
                }
            } 
            return false;
        }

        public bool IsOutboundContainerPalletMessageFlightDataValid(string[] splitMessageContent)
        {
            if (MessageValidation.IsCPMMessageTypeValid(splitMessageContent[0]))
            {
                var flightRegex = new Regex(FlightInfoConstants.IsFlightInfoValid);
                var match = flightRegex.Match(splitMessageContent[1]);

                if (match.Success)
                {
                    string flightNumber = match.Groups["flt"].Value;
                    string date = match.Groups["date"].Value;
                    string registration = match.Groups["reg"].Value;
                    string station = match.Groups["origin"].Value;

                    if (MessageValidation.IsFlightInfoNotNullOrWhitespace(flightNumber, registration, date, station))
                    {
                        if (_flightsService.CheckIfFlightIsOutbound(flightNumber))
                        {
                            if (_aircraftService.CheckAircraftRegistration(registration))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool IsOutboundLoadDistributionMessageFlightDataValid(string[] splitMessageContent)
        {
            if (MessageValidation.IsCPMMessageTypeValid(splitMessageContent[0]))
            {
                var flightRegex = new Regex(FlightInfoConstants.IsFlightInfoValid);
                var match = flightRegex.Match(splitMessageContent[1]);

                if (match.Success)
                {
                    string flightNumber = match.Groups["flt"].Value;
                    string date = match.Groups["date"].Value;
                    string registration = match.Groups["reg"].Value;
                    string station = match.Groups["origin"].Value;

                    if (MessageValidation.IsFlightInfoNotNullOrWhitespace(flightNumber, registration, date, station))
                    {
                        if (_flightsService.CheckIfFlightIsOutbound(flightNumber))
                        {
                            if (_aircraftService.CheckAircraftRegistration(registration))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
