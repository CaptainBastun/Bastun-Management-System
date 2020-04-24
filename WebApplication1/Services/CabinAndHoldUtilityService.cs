namespace BMS.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Reflection;
    using BMS.Services.Contracts;
    using BMS.Data.LoadingInstructions;

    public class CabinAndHoldUtilityService : ICabinAndHoldUtilityService
    {
        public Dictionary<string,int> DetermineCabinZonesCapacity(string seatMap)
        {
            var zonesCapacity = new Dictionary<string, int>();

            string[] splitSeatMap =
                seatMap
                .Split("/", StringSplitOptions.RemoveEmptyEntries);

            foreach (var zone in splitSeatMap)
            {
                var zoneType = zone.Remove(0, 1)[0].ToString();
                int zoneCapacity = int.Parse(zone.Remove(0, 2));
                zonesCapacity.Add(zoneType, zoneCapacity);
            }

            return zonesCapacity;
        }

        public List<int> DetermineNumberOfHoldsToCreate(LoadingInstruction activeLoadingInstruction)
        {
            if (activeLoadingInstruction == null)
            {
                throw  new NullReferenceException("No such loading instruction found");
            }

            var amountOfHoldsToCreate = new List<int>();

            var holdNames =
                activeLoadingInstruction
                .GetType()
                .GetProperties()
                .Where(x => x.Name.StartsWith("Hold"));

            foreach (var hold in holdNames)
            {
                var holdValue = (int)activeLoadingInstruction.GetType()
                    .GetProperty(hold.Name)
                    .GetValue(activeLoadingInstruction, null);

                if (holdValue != 0)
                {
                    amountOfHoldsToCreate.Add(holdValue);
                }
            }
            return amountOfHoldsToCreate;
        }
    }
}
