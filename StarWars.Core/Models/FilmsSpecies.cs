using StarWars.Core.Data;
using System;
using System.Collections.Generic;

namespace StarWars.Core.Models
{
    public partial class FilmsSpecies
    {
        public int FilmId { get; set; }
        public int SpeciesId { get; set; }

        public virtual Films Film { get; set; }
        public virtual Species Species { get; set; }
    }
}
