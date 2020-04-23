namespace BMS.Models.ViewModels.Passengers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PassengerOffloadEditInputModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string PassportNumber { get; set; }

        public string Nationality { get; set; }

    }
}
