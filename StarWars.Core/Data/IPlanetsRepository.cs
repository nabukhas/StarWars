using StarWars.Core.Models;
using StarWars.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Core.Data
{
    public interface IPlanetsRepository : IRepository<Planets, int>
    {
        Task<List<PlanetsViewModel>> GetMostAppearedPlanets();
    }
}
