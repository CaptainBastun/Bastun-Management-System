namespace BMS.Data.Models.Cabins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class AircraftCabinZone
    {
        public int Id { get; set; }

        public int AircraftCabinId { get; set; }

        public virtual AircraftCabin? Cabin { get; set; }

        public int CabinCapacity { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }

        public void AddPassenger(Passenger passenger)
        {
            if (Passengers.Count < CabinCapacity)
            {
                Passengers.Add(passenger);
            }
        }

        public bool IsZoneFull()
        {
            return Passengers.Count == CabinCapacity;
        }

        public void SetZoneData(int capacity)
        {
            CabinCapacity = capacity;
        }
    }
}
