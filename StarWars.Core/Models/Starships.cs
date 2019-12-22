using System;
using System.Collections.Generic;

namespace StarWars.Core.Models
{
    public partial class Starships
    {
        public Starships()
        {
            FilmsStarships = new HashSet<FilmsStarships>();
            StarshipsPilots = new HashSet<StarshipsPilots>();
        }

        public int Id { get; set; }
        public string Mglt { get; set; }
        public string HyperdriveRating { get; set; }
        public string StarshipClass { get; set; }

        public virtual ICollection<FilmsStarships> FilmsStarships { get; set; }
        public virtual ICollection<StarshipsPilots> StarshipsPilots { get; set; }
    }
}
