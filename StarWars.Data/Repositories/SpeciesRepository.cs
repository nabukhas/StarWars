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

    public class SpeciesRepository : EfRepository<Species, int>, ISpeciesRepository
    {
        public SpeciesRepository() { }

        public SpeciesRepository(StarwarsContext db, ILogger<ISpeciesRepository> logger)
            : base(db, logger)
        {
        }

        public async Task<List<SpeciesViewModel>> GetMostAppearedSpecies()
        {

            var mostAppearedSpecies = _db.Set<FilmsCharacters>()
            .Join(_db.Set<SpeciesPeople>(), filmChar => filmChar.PeopleId, speciesPeople => speciesPeople.PeopleId, (filmChar, speciesPeople) => new { filmChar, speciesPeople })
            .Join(_db.Set<Species>(), species => species.speciesPeople.SpeciesId, species => species.Id, (fc, sp) => new { fc, sp })
            .GroupBy(x => new { x.fc.speciesPeople.SpeciesId, x.fc.speciesPeople.Species.Name })
            .Select(g => new SpeciesViewModel
            {
                SpeciesId = g.Key.SpeciesId,
                SpeciesName = g.Key.Name,
                SpeciesCharacterCount = g.Count()
            })
            .OrderByDescending(o => o.SpeciesCharacterCount);

            return await mostAppearedSpecies.Take(5).ToListAsync();
        }
    }
}
