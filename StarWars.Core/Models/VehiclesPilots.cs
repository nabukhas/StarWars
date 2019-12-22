using System;
using System.Collections.Generic;

namespace StarWars.Core.Models
{
    public partial class VehiclesPilots
    {
        public int VehicleId { get; set; }
        public int PeopleId { get; set; }

        public virtual People People { get; set; }
        public virtual Vehicles Vehicle { get; set; }
    }
}
