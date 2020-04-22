namespace BMS.Data.Models.Cabins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AircraftCabinZone
    {
        public AircraftCabinZone()
        {
            Passengers = new List<Passenger>();
        }

        public int Id { get; set; }

        public int AircraftCabinId { get; set; }

        public virtual AircraftCabin Cabin { get; set; }

        public int ZoneCapacity { get; set; }

        public string ZoneType { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }

        public void AddPassenger(Passenger passenger)
        {
            if (Passengers.Count < ZoneCapacity)
            {
                Passengers.Add(passenger);
            }
        }

        public bool IsZoneFull()
        {
            return Passengers.Count == ZoneCapacity;
        }

        public void SetZoneData(int capacity)
        {
            ZoneCapacity = capacity;
        }
    }
}
