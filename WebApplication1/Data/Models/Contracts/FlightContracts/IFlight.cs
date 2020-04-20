﻿namespace BMS.Data.Models.Contracts.FlightContracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IFlight
    {
        public string FlightNumber { get; set; }

        public DateTime STA { get; set; }

        public DateTime STD { get; set; }

        public string SeatMap { get; set; }
    }
}
