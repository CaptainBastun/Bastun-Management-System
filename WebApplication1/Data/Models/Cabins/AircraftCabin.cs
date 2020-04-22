namespace BMS.Data.Models
{
    using BMS.Data.Models.Cabins;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class AircraftCabin
    {
        public AircraftCabin()
        {
            Zones = new List<AircraftCabinZone>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int AircraftId { get; set; }

        [Required]
        public virtual Aircraft Aircraft { get; set; }

        public virtual ICollection<AircraftCabinZone> Zones { get; set; }

    }
}
