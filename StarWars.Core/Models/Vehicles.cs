using System;
using System.Collections.Generic;

namespace StarWars.Core.Models
{
    public partial class Vehicles
    {
        public Vehicles()
        {
            FilmsVehicles = new HashSet<FilmsVehicles>();
            VehiclesPilots = new HashSet<VehiclesPilots>();
        }

        public int Id { get; set; }
        public string VehicleClass { get; set; }

        public virtual ICollection<FilmsVehicles> FilmsVehicles { get; set; }
        public virtual ICollection<VehiclesPilots> VehiclesPilots { get; set; }
    }
}
