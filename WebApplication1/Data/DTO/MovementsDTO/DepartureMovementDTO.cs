namespace BMS.Data.DTO.MovementsDTO
{
    using BMS.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DepartureMovementDTO
    {
        public DepartureMovementDTO(DateTime[] depMvtTimes, string supplementaryInformation, int totalPax)
        {
            DateOfMovement = DateTime.UtcNow;
            OffBlockTime = depMvtTimes[0];
            TakeoffTime = depMvtTimes[1];
            TotalPAX = totalPax;
            SupplementaryInformation = supplementaryInformation;
        }

        public DateTime DateOfMovement { get; set; }

        public DateTime OffBlockTime { get; set; }

        public DateTime TakeoffTime { get; set; }

        public int TotalPAX { get; set; }

        public string SupplementaryInformation { get; set; }
    }
}
