using StarWars.Core.Data;
using System;
using System.Collections.Generic;

namespace StarWars.Core.Models
{
    public partial class FilmsCharacters
    {
        public int FilmId { get; set; }
        public int PeopleId { get; set; }

        public virtual Films Film { get; set; }
        public virtual People People { get; set; }
    }
}
