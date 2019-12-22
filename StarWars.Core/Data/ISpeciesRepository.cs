using StarWars.Core.Models;
using StarWars.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Core.Data
{
    public interface ISpeciesRepository : IRepository<Species, int>
    {
        Task<List<SpeciesViewModel>> GetMostAppearedSpecies();
    }
}
