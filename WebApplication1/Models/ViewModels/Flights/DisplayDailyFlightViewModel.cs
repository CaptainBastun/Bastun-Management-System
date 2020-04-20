namespace BMS.Models.ViewModels.Flights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DisplayDailyFlightViewModel
    {
        public DisplayDailyFlightViewModel(List<FlightViewModel> flights)
        {
            Flights = flights;
        }
        public List<FlightViewModel> Flights { get; set; }
    }
}
