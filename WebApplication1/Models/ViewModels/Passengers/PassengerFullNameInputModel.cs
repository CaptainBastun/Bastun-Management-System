namespace BMS.Models.ViewModels.Passengers
{
    using BMS.GlobalData.PAXConstants.PAXErrorMessages;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    public class PassengerFullNameInputModel
    {
        [Required(ErrorMessage = PassengerErrors.PassengerFullNameRequired)]
        public string FullName { get; set; }
    }
}
