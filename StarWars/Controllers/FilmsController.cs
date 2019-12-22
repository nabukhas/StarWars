using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWars.Core.Data;
using StarWars.Core.Models;

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FilmsController : ControllerBase
    {

        private readonly IFilmsRepository _repository;

        public FilmsController(IFilmsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Films>> GetFilms()
        {
            return await _repository.GetLongestOpeningCrawl();
        }
    }
}
