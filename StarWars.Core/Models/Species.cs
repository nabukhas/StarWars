using StarWars.Core.Data;
using System;
using System.Collections.Generic;

namespace StarWars.Core.Models
{
    public partial class Species : IEntity<int>
    {
        public Species()
        {
            FilmsSpecies = new HashSet<FilmsSpecies>();
            SpeciesPeople = new HashSet<SpeciesPeople>();
        }

        public int Id { get; set; }
        public string AverageHeight { get; set; }
        public string AverageLifespan { get; set; }
        public string Classification { get; set; }
        public DateTime? Created { get; set; }
        public string Designation { get; set; }
        public DateTime? Edited { get; set; }
        public string EyeColors { get; set; }
        public string HairColors { get; set; }
        public int? Homeworld { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string SkinColors { get; set; }
        public int count { get; set; }

        public virtual ICollection<FilmsSpecies> FilmsSpecies { get; set; }
        public virtual ICollection<SpeciesPeople> SpeciesPeople { get; set; }
    }
}
