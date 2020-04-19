namespace BMS.Data.DTO.MovementsDTO
{
    using BMS.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class ArrivalMovementDTO
    {

        public ArrivalMovementDTO(DateTime[] arrMvtTimes, string supplementaryInformation)
        {
            SupplementaryInformation = supplementaryInformation;
            TouchdownTime = arrMvtTimes[0];
            OnBlockTime = arrMvtTimes[1];
            DateOfMovement = DateTime.UtcNow;
        }

        public DateTime DateOfMovement { get; set; }

        public DateTime TouchdownTime { get; set; }

        public DateTime OnBlockTime { get; set; }

        public string SupplementaryInformation { get; set; }
    }
}
