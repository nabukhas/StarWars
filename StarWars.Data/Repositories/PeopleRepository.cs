using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StarWars.Core.Data;
using StarWars.Core.Models;
using StarWars.Data.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Data.Repositories
{

    public class PeopleRepository : EfRepository<People, int>, IPeopleRepository
    {
        public PeopleRepository() { }

        public PeopleRepository(StarwarsContext db, ILogger<FilmsRepository> logger)
            : base(db, logger)
        {
        }

        public async Task<People> GetMostAppearedPerson()
        {
            var mostAppeared = _dbSet.OrderByDescending(o => o.FilmsCharacters.Count);
            return await mostAppeared.FirstOrDefaultAsync();
        }
    }
}
