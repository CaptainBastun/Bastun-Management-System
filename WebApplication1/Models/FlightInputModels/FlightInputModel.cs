namespace BMS.Models
{
    using BMS.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using BMS.GlobalData;
    using BMS.GlobalData.ErrorMessages;
    using BMS.Models.FlightInputModels;

    public class FlightInputModel
    {
        public InboundFlightInputModel InboundInputModel { get; set; }

        public OutboundFlightInputModel OutboundInputModel { get; set; }
    }
}
