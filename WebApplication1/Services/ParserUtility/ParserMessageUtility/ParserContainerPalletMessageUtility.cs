using BMS.Services.ParserUtility.UtilityContracts;

namespace BMS.Services.ParserUtility.ParserMessageUtility
{
    public class ParserContainerPalletMessageUtility : IParserContainerPalletMessageUtility
    {
        public int GetContainerCount(string[] splitCpmData)
        {
            int containerCount = 0;

            for (int i = 2; i < splitCpmData.Length - 1; i++)
            {
                containerCount++;
            }

            return containerCount;
        }
    }
}
