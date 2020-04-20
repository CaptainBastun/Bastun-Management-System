namespace BMS.Data.Models
{
    using BMS.Data.Models.BaggageHolds.AircraftBaggageCompartments;
    using BMS.Data.Models.BaggageHolds.AircraftBaggageHolds;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    public class AircraftBaggageHold
    {
        [Key]
        public int BaggageHoldId { get; set; }

        [Required]
        public int AircraftId { get; set; }

        [Required]
        public virtual Aircraft Aircraft { get; set; }


        public virtual ICollection<Compartment> Compartments { get; set; }

        //public int CompartmentOneId { get; set; }

        //public virtual CompartmentOne? CompartmentOne { get; set; }

        //public int CompartmentTwoId { get; set; }

        //public virtual CompartmentTwo? CompartmentTwo { get; set; }

        //public int CompartmentThreeId { get; set; }

        //public virtual CompartmentThree? CompartmentThree { get; set; }

        //public int CompartmentFourId { get; set; }

        //public virtual CompartmentFour? CompartmentFour { get; set; }

        //public int CompartmentFiveId { get; set; }

        //public virtual CompartmentFive? CompartmentFive { get; set; }


    }
}
