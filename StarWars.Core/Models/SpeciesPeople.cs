using System;
using System.Collections.Generic;

namespace StarWars.Core.Models
{
    public partial class SpeciesPeople
    {
        public int SpeciesId { get; set; }
        public int PeopleId { get; set; }

        public virtual People People { get; set; }
        public virtual Species Species { get; set; }
    }
}
