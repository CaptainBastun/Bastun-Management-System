namespace BMS.Models.ViewModels.Passengers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PassengerOffloadEditViewModel
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nationality { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string PassportNumber { get; set; }

        public PassengerOffloadEditInputModel OffloadEditInputModel { get; set; }
    }
}
