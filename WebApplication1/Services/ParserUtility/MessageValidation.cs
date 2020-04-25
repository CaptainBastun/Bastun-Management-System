namespace BMS.Services.ParserUtility
{
    public static class MessageValidation
    {

        public static bool IsMovementMessageTypeValid(string messageType)
        {
            return messageType == "MVT";
        } 

        public static bool IsLoadDistributionMessageTypeValid(string messageType)
        {
            return messageType == "LDM";
        }

        public static bool IsCPMMessageTypeValid(string messageType)
        {
            return messageType == "CPM";
        }

        public static bool IsUCMMessageTypeValid(string messageType)
        {
            return messageType == "UCM";
        }

        public static bool IsFlightInfoNotNullOrWhitespace(string flightNumber, string registration, string date)
        {
            if (string.IsNullOrWhiteSpace(flightNumber))
            {
                return false; 
            }

            if (string.IsNullOrWhiteSpace(registration))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(date))
            {
                return false;
            }

   
            return true;
        }
    }
}
