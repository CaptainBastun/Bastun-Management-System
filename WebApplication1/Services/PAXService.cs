namespace BMS.Services
{
    using BMS.Models;
    using BMS.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class PAXService : IPAXService
    {
        public void AddPAXToZoneAlpha(PAXInputModel paxInputModel)
        {
            throw new NotImplementedException();
        }

        public void AddPAXToZoneBravo(PAXInputModel paxInputModel)
        {
            throw new NotImplementedException();
        }

        public void AddPAXToZoneCharlie(PAXInputModel pAXInputModel)
        {
            throw new NotImplementedException();
        }

        public string GetPaxZoneBySeatNumber(string paxSeatNumber)
        {
            return null;
        }

        public int SetPaxAge(string paxGender)
        {
            int result = 0;
            switch (paxGender)
            {
                case "M":
                    result = 88;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
