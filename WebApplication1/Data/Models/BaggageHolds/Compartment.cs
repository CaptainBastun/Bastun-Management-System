namespace BMS.Data.Models.BaggageHolds.AircraftBaggageHolds
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Compartment
    {
        public Compartment()
        {
            Suitcases = new List<Suitcase>();
        }

        [Key]
        public int  Id { get; set; }

        public int PiecesToPutInCompartment { get; set; }

        public int CurrentPiecesInCompartment { get; set; }

        public int MaxCompartmentWeight { get; set; }

        public int TotalWeightInCompartment { get; set; }

        public int BaggageHoldId { get; set; }

        public virtual AircraftBaggageHold BaggageHold { get; set; }

        public virtual ICollection<Suitcase> Suitcases { get; set; }

        public bool IsHoldFull()
        {
            return CurrentPiecesInCompartment == PiecesToPutInCompartment;
        }

        public void AddSuitcase(Suitcase suitcase)
        {
            if ((TotalWeightInCompartment + suitcase.Weight) < MaxCompartmentWeight)
            {
                Suitcases.Add(suitcase);
                TotalWeightInCompartment += suitcase.Weight;
                CurrentPiecesInCompartment++;
            }
        }

    }
}
