using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StarWars.Core.Data;
using StarWars.Core.Models;
using StarWars.Core.ViewModel;
using StarWars.Data.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Data.Repositories
{

    public class PlanetsRepository : EfRepository<Planets, int>, IPlanetsRepository
    {
        public PlanetsRepository() { }

        public PlanetsRepository(StarwarsContext db, ILogger<IPlanetsRepository> logger)
            : base(db, logger)
        {
        }

        public async Task<List<PlanetsViewModel>> GetMostAppearedPlanets()
        {
            var mostAppearedSpecies = _db.Set<VehiclesPilots>()
            .Join(_db.Set<Vehicles>(), vehiclesPilots => vehiclesPilots.VehicleId, vehicles => vehicles.Id, (vehiclesPilots, vehicles) => new { vehiclesPilots, vehicles })
            .Join(_db.Set<People>(), vehiclesPilotsJoin => vehiclesPilotsJoin.vehiclesPilots.PeopleId, people => people.Id, (vehiclesPilotsJoin, people) => new { vehiclesPilotsJoin, people })
            .Join(_db.Set<SpeciesPeople>(), peopleJoin => peopleJoin.people.Id, speciesPeople => speciesPeople.PeopleId, (peopleJoin, speciesPeople) => new { peopleJoin, speciesPeople })
            .Join(_db.Set<Species>(), speciesPeopleJoin => speciesPeopleJoin.speciesPeople.SpeciesId, species => species.Id, (speciesPeopleJoin, species) => new { speciesPeopleJoin, species })
            .Join(_db.Set<FilmsCharacters>(), filmsCharactersJoin => filmsCharactersJoin.speciesPeopleJoin.peopleJoin.people.Id, filmsCharacters => filmsCharacters.PeopleId, (filmsCharactersJoin, filmsCharacters) => new { filmsCharactersJoin, filmsCharacters })
            .Join(_db.Set<Films>(), filmsJoin => filmsJoin.filmsCharacters.FilmId, films => films.Id, (filmsJoin, films) => new { filmsJoin, films })
            .Join(_db.Set<FilmsPlanets>(), filmsPlanetsJoin => filmsPlanetsJoin.films.Id, filmsPlanets => filmsPlanets.FilmId, (filmsPlanetsJoin, filmsPlanets) => new { filmsPlanetsJoin, filmsPlanets })
            .Join(_db.Set<Planets>(), planetsJoin => planetsJoin.filmsPlanets.PlanetId, planets => planets.Id, (planetsJoin, planets) => new { planetsJoin, planets })
            .GroupBy(x => new { PlanetName = x.planets.Name, PeopleName = x.planetsJoin.filmsPlanetsJoin.filmsJoin.filmsCharacters.People.Name, SpeciesName = x.planetsJoin.filmsPlanetsJoin.filmsJoin.filmsCharactersJoin.species.Name })
            .Select(g => new PlanetsViewModel
            {
                PilotName = g.Key.PeopleName,
                SpeciesName = g.Key.SpeciesName,
                PlanetName = g.Key.PlanetName,
                PilotsCount = g.Count()
            })
            .OrderByDescending(o => o.PilotsCount);

            return await mostAppearedSpecies.Take(10).ToListAsync();
        }
    }
}
