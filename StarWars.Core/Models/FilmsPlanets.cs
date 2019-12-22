using StarWars.Core.Data;
using System;
using System.Collections.Generic;

namespace StarWars.Core.Models
{
    public partial class FilmsPlanets
    {
        public int FilmId { get; set; }
        public int PlanetId { get; set; }

        public virtual Films Film { get; set; }
        public virtual Planets Planet { get; set; }
    }
}
