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

    public class FilmsRepository : EfRepository<Films, int>, IFilmsRepository
    {
        public FilmsRepository() { }

        public FilmsRepository(StarwarsContext db, ILogger<FilmsRepository> logger)
            : base(db, logger)
        {
        }

        public async Task<Films> GetLongestOpeningCrawl()
        {
            var longest = _dbSet.ToList().Aggregate((i1, i2) => i1.OpeningCrawl.Length > i2.OpeningCrawl.Length ? i1 : i2);
            return await _dbSet.FirstOrDefaultAsync(o => o.Id == longest.Id);

        }
    }
}
