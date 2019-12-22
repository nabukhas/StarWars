using System;
using System.Collections.Generic;

namespace StarWars.Core.Models
{
    public partial class Transports
    {
        public int Id { get; set; }
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public string CostInCredits { get; set; }
        public DateTime? Created { get; set; }
        public string Crew { get; set; }
        public DateTime? Edited { get; set; }
        public string Length { get; set; }
        public string Manufacturer { get; set; }
        public string MaxAtmospheringSpeed { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Passengers { get; set; }
    }
}
