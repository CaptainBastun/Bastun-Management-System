namespace BMS.Data.Models.BaggageHolds.AircraftBaggageHolds
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class Compartment
    {
        protected Compartment()
        {
            Suitcases = new List<Suitcase>();
        }

        [Key]
        public int  Id { get; set; }

        public int PiecesToPutInHold { get; set; }

        public int CurrentPiecesInHold { get; set; }

        public int MaxHoldWeightCapacity { get; set; }

        public int TotalWeightInHold { get; set; }

        public int BaggageHoldId { get; set; }

        public virtual AircraftBaggageHold BaggageHold { get; set; }

        public virtual ICollection<Suitcase> Suitcases { get; set; }

        public bool IsHoldFull()
        {
            return CurrentPiecesInHold == PiecesToPutInHold;
        }

        public void AddSuitcase(Suitcase suitcase)
        {
            if ((TotalWeightInHold + suitcase.Weight) < MaxHoldWeightCapacity)
            {
                Suitcases.Add(suitcase);
                TotalWeightInHold += suitcase.Weight;
                CurrentPiecesInHold++;
            }
        }

    }
}
