namespace BMS.Services.ParserUtility.UtilityContracts
{
    using BMS.Data.Models;
    using System;
    using System.Text.RegularExpressions;
    public interface IParserDepartureMovementUtility
    {
        Regex MovementFlightData { get; set; }

        string[] GetMovementFlightData(string flightData);

        string[] GetTimes(string timeData);

        string[] GetValidTimesFormat(string[] listOfTimes);

        DateTime[] ParseMovementTimes(string[] flightData,OutboundFlight flight);
    }
}
