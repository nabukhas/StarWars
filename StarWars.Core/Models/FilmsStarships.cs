using StarWars.Core.Data;
using System;
using System.Collections.Generic;

namespace StarWars.Core.Models
{
    public partial class FilmsStarships
    {
        public int FilmId { get; set; }
        public int StarshipId { get; set; }

        public virtual Films Film { get; set; }
        public virtual Starships Starship { get; set; }
    }
}
