using StarWars.Core.Data;
using System;
using System.Collections.Generic;

namespace StarWars.Core.Models
{
    public partial class People : IEntity<int>
    {
        public People()
        {
            FilmsCharacters = new HashSet<FilmsCharacters>();
            SpeciesPeople = new HashSet<SpeciesPeople>();
            StarshipsPilots = new HashSet<StarshipsPilots>();
            VehiclesPilots = new HashSet<VehiclesPilots>();
        }

        public int Id { get; set; }
        public string BirthYear { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Edited { get; set; }
        public string EyeColor { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public string Height { get; set; }
        public int? Homeworld { get; set; }
        public string Mass { get; set; }
        public string Name { get; set; }
        public string SkinColor { get; set; }

        public virtual ICollection<FilmsCharacters> FilmsCharacters { get; set; }
        public virtual ICollection<SpeciesPeople> SpeciesPeople { get; set; }
        public virtual ICollection<StarshipsPilots> StarshipsPilots { get; set; }
        public virtual ICollection<VehiclesPilots> VehiclesPilots { get; set; }
    }
}
