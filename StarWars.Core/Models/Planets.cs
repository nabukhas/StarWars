using StarWars.Core.Data;
using System;
using System.Collections.Generic;

namespace StarWars.Core.Models
{
    public partial class Planets : IEntity<int>
    {
        public Planets()
        {
            FilmsPlanets = new HashSet<FilmsPlanets>();
        }

        public int Id { get; set; }
        public string Climate { get; set; }
        public DateTime? Created { get; set; }
        public string Diameter { get; set; }
        public DateTime? Edited { get; set; }
        public string Gravity { get; set; }
        public string Name { get; set; }
        public string OrbitalPeriod { get; set; }
        public string Population { get; set; }
        public string RotationPeriod { get; set; }
        public string SurfaceWater { get; set; }
        public string Terrain { get; set; }

        public virtual ICollection<FilmsPlanets> FilmsPlanets { get; set; }
    }
}
